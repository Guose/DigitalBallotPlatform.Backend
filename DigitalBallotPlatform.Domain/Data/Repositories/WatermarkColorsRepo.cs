using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Watermark.DTOs;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class WatermarkColorsRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<WatermarkColorDTO, ElectionDbContext>(context, logger), IWatermarkColorsRepo
    {
        public async Task<bool> ExecuteUpdateAsync(WatermarkColorDTO watermarkColorDTO)
        {
            try
            {
                WatermarkColorModel? watermark = await Context.WatermarkColors.FirstOrDefaultAsyncEF(w => w.Id == watermarkColorDTO.Id);
                if (watermark == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                watermark = await WatermarkColorDTO.MapWatermarkColorModel(watermarkColorDTO);

                Context.WatermarkColors.Update(watermark);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been updated", nameof(WatermarkColorModel), nameof(ExecuteUpdateAsync));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<WatermarkColorDTO?> GetWatermarkColorById(int id)
        {
            try
            {
                WatermarkColorModel? watermark = await Context.WatermarkColors.FirstOrDefaultAsyncEF(w => w.Id == id);

                if (watermark == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetWatermarkColorById), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(WatermarkColorModel), nameof(GetWatermarkColorById), id);

                return await WatermarkColorDTO.MapWatermarkColorDto(watermark);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetWatermarkColorById));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
