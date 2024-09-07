using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Platform.DTOs;
using DigitalBallotPlatform.Shared.Logger;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class RoleRepo(PlatformDbContext context, ILogger logger) : 
        GenericRepository<RoleDTO, PlatformDbContext>(context, logger), IRoleRepo
    {
        public Task<bool> ExecuteUpdateAsync(RoleDTO roleDto)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDTO?> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
