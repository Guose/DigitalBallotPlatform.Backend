using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class ElectionSetupRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<ElectionSetupDTO, ElectionDbContext>(context, logger), IElectionSetupRepo
    {
        public async Task<bool> ExecuteUpdateAsync(ElectionSetupDTO electionSetupDTO)
        {
            try
            {
                ElectionSetupModel? electionSetup = await Context.ElectionSetups.FirstOrDefaultAsyncEF(e => e.Id == electionSetupDTO.Id);
                if (electionSetup == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                electionSetup = await ElectionSetupDTO.MapElectionSetupModel(electionSetupDTO);

                Context.ElectionSetups.Update(electionSetup);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been updated", nameof(ElectionSetupModel), nameof(ExecuteUpdateAsync));

                return true;
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ElectionSetupDTO?> GetElectionByIdAsync(int id)
        {
            try
            {
                ElectionSetupModel? electionSetup = await Context.ElectionSetups.FirstOrDefaultAsyncEF(e => e.Id == id);

                if (electionSetup == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetElectionByIdAsync), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(ElectionSetupModel), nameof(GetElectionByIdAsync), id);


                return await ElectionSetupDTO.MapElectionSetupDTO(electionSetup);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] Message: {0} InnerException: {1}", ex.Message, ex.InnerException!);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
