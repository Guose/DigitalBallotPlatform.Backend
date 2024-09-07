using DigitalBallotPlatform.Platform.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IRoleRepo : IGenericRepository<RoleModel>
    {
        Task<bool> ExecuteUpdateAsync(RoleDTO roleDto);
        Task<RoleDTO?> GetRoleByIdAsync(int id);
    }
}
