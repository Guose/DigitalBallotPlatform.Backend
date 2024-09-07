using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IBallotSpecsLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBallotSpecsLookupAsync();
    }
}
