using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class ElectionSetupRepo : GenericRepository<ElectionSetupDTO, ElectionDbContext>, IElectionSetupRepo
    {
        private readonly ILogger logger;

        public ElectionSetupRepo(ElectionDbContext context, ILogger logger) : base(context, logger)
        {
            this.logger = logger;
        }

        public async Task<bool> ExecuteUpdateAsync(ElectionSetupDTO electionSetupDTO)
        {
            try
            {
                ElectionSetupModel? electionSetup = await Context.ElectionSetups.FirstOrDefaultAsyncEF(e => e.Id == electionSetupDTO.Id);
                if (electionSetup == null)
                    return false;

                electionSetup = await ElectionSetupDTO.MapElectionSetupModel(electionSetupDTO);

                Context.ElectionSetups.Update(electionSetup);
                await SaveAsync();

                Logger.LogInformation("[INFO] {1} Message: Entity {0} has been updated", nameof(ElectionSetupModel), nameof(ExecuteUpdateAsync));

                return true;
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ElectionSetupDTO?> GetElectionByIdAsync(int id)
        {
            try
            {
                ElectionSetupModel? electionSetup = await Context.ElectionSetups.FirstOrDefaultAsyncEF(e => e.Id == id);

                if (electionSetup == null)
                    return null;

                Logger.LogInformation("[INFO] {1} Message: Entity {0} query for Id: {2} was successfull", nameof(ElectionSetupModel), nameof(GetElectionByIdAsync), id);


                return await ElectionSetupDTO.MapElectionSetupDTO(electionSetup);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] Message: {0} InnerException: {1}", ex.Message, ex.InnerException!);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
