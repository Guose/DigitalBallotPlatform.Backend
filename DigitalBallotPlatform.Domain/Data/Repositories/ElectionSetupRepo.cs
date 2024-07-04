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

        public ElectionSetupRepo(ElectionDbContext context, ILogger logger) : base(context)
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

                electionSetup = ElectionSetupDTO.MapElectionSetupDTO(electionSetupDTO);

                Context.ElectionSetups.Update(electionSetup);
                await SaveAsync();

                logger.LogInformation("[INFO] Election ID {0} has been updated", electionSetup.Id);

                return true;
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] Message: {0} InnerException: {1}", ex.Message, ex.InnerException!);
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ElectionSetupDTO?> GetElectionByIdAsync(int id)
        {
            try
            {
                ElectionSetupModel? electionSetup = await Context.ElectionSetups.FirstOrDefaultAsyncEF(e => e.Id == id);

                if (electionSetup != null)
                    return ElectionSetupDTO.MapElectionSetupEntity(electionSetup);

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] Message: {0} InnerException: {1}", ex.Message, ex.InnerException!);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
