using DigitalBallotPlatform.Api.Services;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Platform.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBallotPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private readonly IPlatformUserRepo userRepo;

        public AuthController(ITokenService tokenService, IPlatformUserRepo userRepo)
        {
            this.tokenService = tokenService;
            this.userRepo = userRepo;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO login)
        {
            PlatformUserDTO? userDto = await userRepo.ValidateUsernameAsync(login.Username);

            if (userDto == null)
            {
                return NotFound("Username does not exist");
            }

            if (login.Username == userDto.Username && login.Password == userDto.Password)
            {
                var token = tokenService.GenerateToken(login.Username, login.Password, login.AuthInterval);
                return Ok(new { User = userDto, Token = token });
            }

            return Unauthorized();
        }

        [HttpPost("RenewToken")]
        public async Task<IActionResult> RenewToken([FromBody] TokenRenewalRequest request)
        {
            var principal = tokenService.GetPrincipalFromExpiredToken(request.Token);
            if (principal == null)
            {
                return Unauthorized();
            }

            var username = principal.Identity?.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var userDto = await userRepo.ValidateUsernameAsync(username);
            if (userDto == null)
            {
                return Unauthorized();
            }

            // Generate a new token with an extended expiration
            var newToken = tokenService.GenerateToken(userDto.Username, userDto.Password, request.AuthInterval);
            return Ok(new { Token = newToken });
        }
    }
}
