using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class BallotSpecRepo(BallotDbContext context, ILogger logger) : 
        GenericRepository<BallotSpecDTO, BallotDbContext>(context, logger), IBallotSpecRepo
    {
        public Task<bool> ExecuteUpdateAsync(BallotSpecDTO ballotSpecDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BallotSpecDTO?> GetBallotSpecByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
