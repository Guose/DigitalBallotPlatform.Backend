using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Watermark.DTOs;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class WatermarkRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<WatermarkModel, ElectionDbContext>(context, logger), IWatermarkRepo
    {
        public async Task<bool> ExecuteUpdateAsync(WatermarkDTO watermarkDTO)
        {
            try
            {
                WatermarkModel? watermark = await Context.Watermarks.AsNoTracking().FirstOrDefaultAsyncEF(w => w.Id == watermarkDTO.Id);
                if (watermark == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                watermark = await WatermarkDTO.MapWatermarkModel(watermarkDTO);

                Context.Watermarks.Update(watermark);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been updated", nameof(WatermarkModel), nameof(ExecuteUpdateAsync));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<WatermarkDTO?> GetWatermarkById(int id)
        {
            try
            {
                WatermarkModel? watermark = await Context.Watermarks.AsNoTracking().FirstOrDefaultAsyncEF(w => w.Id == id);

                if (watermark == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetWatermarkById), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(PartyModel), nameof(GetWatermarkById), id);

                return await WatermarkDTO.MapWatermarkDto(watermark);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetWatermarkById));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
