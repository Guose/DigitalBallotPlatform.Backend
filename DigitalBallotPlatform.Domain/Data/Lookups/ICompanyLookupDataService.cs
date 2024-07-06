using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface ICompanyLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetCompanyLookupAsync();
    }
}
