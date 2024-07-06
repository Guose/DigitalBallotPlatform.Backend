using DigitalBallotPlatform.County.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class CountyRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<CountyDTO, ElectionDbContext>(context, logger), ICountyRepo
    {
        public async Task<bool> ExecuteUpdateAsync(CountyDTO countyDto)
        {
            try
            {                
                CountyModel? county = await Context.Counties.FirstOrDefaultAsyncEF(c => c.Id == countyDto.Id);
                if (county == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                county = await CountyDTO.MapCountyModel(countyDto);

                Context.Counties.Update(county);
                await SaveAsync();

                Logger.LogInformation("[INFO] {0} Entity {1} has been updated", nameof(ExecuteUpdateAsync), nameof(CountyModel));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<CountyDTO?> GetCountyByIdAsync(int id)
        {
            try
            {
                CountyModel? county = await Context.Counties.FirstOrDefaultAsyncEF(c => c.Id == id);
                if (county == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetCountyByIdAsync), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {0} Message: Entity {1} query for ID: {2} was successfull", nameof(GetCountyByIdAsync), nameof(CountyModel), id);

                return await CountyDTO.MapCountyDto(county);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetCountyByIdAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
