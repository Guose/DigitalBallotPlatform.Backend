using DigitalBallotPlatform.Platform.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IRoleRepo : IGenericRepository<RoleDTO>
    {
        Task<bool> ExecuteUpdateAsync(RoleDTO roleDto);
        Task<RoleDTO?> GetRoleByIdAsync(int id);
    }
}
