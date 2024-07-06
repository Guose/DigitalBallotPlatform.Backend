using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public interface IWatermarkColorLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetWatermarkColorLookupAsync();
    }
}
