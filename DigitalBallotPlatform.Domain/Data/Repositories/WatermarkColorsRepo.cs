using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Watermark.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class WatermarkColorsRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<WatermarkColorDTO, ElectionDbContext>(context, logger), IWatermarkColorsRepo
    {
        public Task<bool> ExecuteUpdateAsync(WatermarkColorDTO watermarkColorDTO)
        {
            throw new NotImplementedException();
        }

        public Task<WatermarkColorDTO> GetWatermarkColorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
