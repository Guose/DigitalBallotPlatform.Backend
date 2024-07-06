using DigitalBallotPlatform.Ballot.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IBallotSpecRepo : IGenericRepository<BallotSpecDTO>
    {
        Task<bool> ExecuteUpdateAsync(BallotSpecDTO ballotSpecDTO); 
        Task<BallotSpecDTO?> GetBallotSpecByIdAsync(int id);
    }
}
