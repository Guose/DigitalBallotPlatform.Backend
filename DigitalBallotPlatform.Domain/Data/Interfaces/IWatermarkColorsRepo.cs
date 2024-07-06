using DigitalBallotPlatform.Watermark.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IWatermarkColorsRepo : IGenericRepository<WatermarkColorDTO>
    {
        Task<bool> ExecuteUpdateAsync(WatermarkColorDTO watermarkColorDTO);
        Task<WatermarkColorDTO?> GetWatermarkColorById(int id);
    }
}
