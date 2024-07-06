using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IRoleLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetRoleLookupAsync();
    }
}
