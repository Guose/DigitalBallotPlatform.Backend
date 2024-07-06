using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IBallotCategoryLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBallotCategoryLookupAsync();
    }
}
