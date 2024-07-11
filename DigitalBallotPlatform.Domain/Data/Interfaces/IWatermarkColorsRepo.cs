using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Watermark.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IWatermarkColorsRepo : IGenericRepository<WatermarkColorModel>
    {
        Task<bool> ExecuteUpdateAsync(WatermarkColorDTO watermarkColorDTO);
        Task<WatermarkColorDTO?> GetWatermarkColorById(int id);
    }
}
