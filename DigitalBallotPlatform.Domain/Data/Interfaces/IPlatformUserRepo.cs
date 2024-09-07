using DigitalBallotPlatform.Platform.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IPlatformUserRepo : IGenericRepository<PlatformUserModel>
    {
        Task<bool> ExecuteUpdateAsync(PlatformUserDTO userDto);
        Task<PlatformUserDTO?> GetUserByIdAsync(Guid id);
        Task<PlatformUserDTO?> ValidateUsernameAsync(string username);
    }
}
