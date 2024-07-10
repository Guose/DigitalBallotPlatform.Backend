using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IBallotCategoryRepo : IGenericRepository<BallotCategoryModel>
    {
        Task<bool> ExecuteUpdateAsync(BallotCategoryDTO ballotCategoryDto);
        Task<BallotCategoryDTO?> GetBallotCategoryByIdAsync(int id);
    }
}
