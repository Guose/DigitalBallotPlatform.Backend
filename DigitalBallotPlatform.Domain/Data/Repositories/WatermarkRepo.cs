using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Watermark.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class WatermarkRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<WatermarkDTO, ElectionDbContext>(context, logger), IWatermarkRepo
    {
        public Task<bool> ExecuteUpdateAsync(WatermarkDTO watermarkDTO)
        {
            throw new NotImplementedException();
        }

        public Task<WatermarkDTO> GetWatermarkById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
