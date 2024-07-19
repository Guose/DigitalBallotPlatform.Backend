using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Platform.DTOs;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBallotPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformUserRepo platformUserRepo;
        private readonly IRoleRepo roleRepo;

        public PlatformController(IPlatformUserRepo platformUserRepo, IRoleRepo roleRepo)
        {
            this.platformUserRepo = platformUserRepo;
            this.roleRepo = roleRepo;
        }

        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<PlatformUserDTO>>> GetUsers()
        {
            IEnumerable<PlatformUserModel> users = await platformUserRepo.GetAllAsync();

            return users != null ?
                Ok(users) :
                NotFound(new { Message = $"{nameof(PlatformUserDTO)} request could not be found." });
        }

        [HttpGet("User/{id}")]
        public async Task<ActionResult<PlatformUserDTO>> GetUsersById(Guid id)
        {
            PlatformUserDTO? user = await platformUserRepo.GetUserByIdAsync(id);

            return user != null ?
                Ok(user) :
                NotFound(new { Message = $"{nameof(PlatformUserDTO)} request could not be found." });
        }

        [HttpPost("User")]
        public async Task<ActionResult> CreatePlatformUser([FromBody] PlatformUserDTO userDto)
        {
            PlatformUserModel user = await PlatformUserDTO.MapPlatformUserModel(userDto);

            if (await platformUserRepo.ExecuteCreateAsync(user))
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpPut("User/{id}")]
        public async Task<ActionResult> UpdatePlatformUser(Guid id, [FromBody] PlatformUserDTO userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }
            if (await platformUserRepo.ExecuteUpdateAsync(userDto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("User/{id}")]
        public async Task<ActionResult> DeletePlatformUser(Guid id)
        {
            PlatformUserDTO? userDto = await platformUserRepo.GetUserByIdAsync(id);

            if (userDto == null)
            {
                return NotFound(new { Message = $"{nameof(PlatformUserDTO)} request could not be found." });
            }

            PlatformUserModel user = await PlatformUserDTO.MapPlatformUserModel(userDto);

            if (await platformUserRepo.ExecuteDeleteAsync(user))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpGet("Role")]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
        {
            IEnumerable<RoleModel> roles = await roleRepo.GetAllAsync();

            return roles != null ?
                Ok(roles) :
                NotFound(new { Message = $"{nameof(RoleDTO)} request could not be found." });
        }

        [HttpGet("Role/{id}")]
        public async Task<ActionResult<RoleDTO>> GetRoleById(int id)
        {
            RoleDTO? role = await roleRepo.GetRoleByIdAsync(id);

            return role != null ?
                Ok(role) :
                NotFound(new { Message = $"{nameof(RoleDTO)} request could not be found." });
        }

        [HttpPost("Role")]
        public async Task<ActionResult> CreateRole([FromBody] RoleDTO roleDto)
        {
            RoleModel? role = await RoleDTO.MapRoleModel(roleDto);

            if (await roleRepo.ExecuteCreateAsync(role))
            {
                return Ok(role);
            }

            return BadRequest();
        }
    }
}
