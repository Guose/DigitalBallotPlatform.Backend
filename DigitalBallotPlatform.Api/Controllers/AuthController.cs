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
            PlatformUserDTO? userDto = await userRepo.GetUserByUserNameAsync(login.Username);

            if (userDto == null)
            {
                return NotFound();
            }

            if (login.Username == userDto.Username && login.Password == userDto.Password)
            {
                var token = tokenService.GenerateToken(login.Username);
                return Ok(new { User = userDto, Token = token });
            }

            return Unauthorized();
        }
    }
}
