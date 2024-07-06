using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IElectionSetupLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetElectionLookupAsync();
    }
}
