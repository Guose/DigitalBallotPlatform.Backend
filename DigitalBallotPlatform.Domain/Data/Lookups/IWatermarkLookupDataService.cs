using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IWatermarkLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetWatermarkLookupAsync();
    }
}
