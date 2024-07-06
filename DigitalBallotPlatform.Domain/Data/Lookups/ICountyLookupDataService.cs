using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface ICountyLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCountyLookupAsync();
    }
}
