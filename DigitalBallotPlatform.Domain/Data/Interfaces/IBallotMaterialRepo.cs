using DigitalBallotPlatform.Ballot.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IBallotMaterialRepo : IGenericRepository<BallotMaterialDTO>
    {
        Task<bool> ExecuteUpdateAsync(BallotMaterialDTO ballotMaterialDTO);
        Task<BallotMaterialDTO?> GetBallotCategoryByIdAsync(int id);
    }
}
