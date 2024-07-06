using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Platform.DTOs;
using DigitalBallotPlatform.Shared.Logger;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class PlatformUserRepo(PlatformDbContext context, ILogger logger) : 
        GenericRepository<PlatformUserDTO, PlatformDbContext>(context, logger), IPlatformUserRepo
    {
        public Task<bool> ExecuteUpdateAsync(PlatformUserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public Task<PlatformUserDTO?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
