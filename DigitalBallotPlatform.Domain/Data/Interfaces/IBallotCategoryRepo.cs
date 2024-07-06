using DigitalBallotPlatform.Ballot.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IBallotCategoryRepo : IGenericRepository<BallotCategoryDTO>
    {
        Task<bool> ExecuteUpdateAsync(BallotCategoryDTO ballotCategoryDto);
        Task<BallotCategoryDTO?> GetBallotCategoryByIdAsync(int id);
    }
}
