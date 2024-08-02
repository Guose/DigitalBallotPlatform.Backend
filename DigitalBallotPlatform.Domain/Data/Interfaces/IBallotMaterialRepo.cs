using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IBallotMaterialRepo : IGenericRepository<BallotMaterialModel>
    {
        Task<bool> ExecuteUpdateAsync(BallotMaterialDTO ballotMaterialDTO);
        Task<BallotMaterialModel?> GetBallotMaterialByIdAsync(int id);
    }
}
