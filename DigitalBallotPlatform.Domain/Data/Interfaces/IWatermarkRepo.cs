using DigitalBallotPlatform.Watermark.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IWatermarkRepo : IGenericRepository<WatermarkDTO>
    {
        Task<bool> ExecuteUpdateAsync(WatermarkDTO watermarkDTO);
        Task<WatermarkDTO> GetWatermarkById(int id);
    }
}
