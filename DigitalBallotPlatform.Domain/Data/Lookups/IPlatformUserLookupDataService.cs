using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IPlatformUserLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetPlatformUserLookupAsync();
    }
}
