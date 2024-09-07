using DigitalBallotPlatform.Platform.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IPlatformUserRepo : IGenericRepository<PlatformUserDTO>
    {
        Task<bool> ExecuteUpdateAsync(PlatformUserDTO userDto);
        Task<PlatformUserDTO?> GetUserByIdAsync(int id);
    }
}
