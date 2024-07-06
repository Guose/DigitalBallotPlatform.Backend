using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IPartyLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetPartyLookupAsync();
    }
}
