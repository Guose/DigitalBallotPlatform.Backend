using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IBallotSpecRepo : IGenericRepository<BallotSpecModel>
    {
        Task<bool> ExecuteUpdateAsync(BallotSpecDTO ballotSpecDTO); 
        Task<BallotSpecDTO?> GetBallotSpecByIdAsync(int id);
    }
}
