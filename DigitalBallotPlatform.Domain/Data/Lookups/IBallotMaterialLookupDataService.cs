using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IBallotMaterialLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetBallotMaterialLookupAsync();
    }
}
