using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Interfaces.Queries;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB;

namespace DigitalBallotPlatform.Election.Queries
{
    public class ElectionSetupRetrieveQuery : IRetrieveQuery<ElectionSetupDTO>
    {
        private readonly ElectionDbContextFactory dbContextFactory;

        public ElectionSetupRetrieveQuery(ElectionDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<ElectionSetupDTO>> GetAllEntitiesAsync()
        {
            using (var context = dbContextFactory.Create())
            {
                IEnumerable<ElectionSetupModel> electionSetup = await context.ElectionSetups!.ToListAsync();

                return electionSetup.Select(e => new ElectionSetupDTO(
                    e.Id, 
                    e.ElectionDate, 
                    e.Description!, 
                    e.WatermarkId, 
                    e.CountyId, 
                    e.BallotSpecsId));
            }
        }

        public async Task<ElectionSetupDTO> GetEntityByIdAsync(int id)
        {
            using (var context = dbContextFactory.Create())
            {
                ElectionSetupModel electionSetup = await context.ElectionSetups.FirstAsync(ele => ele.Id == id);

                return new ElectionSetupDTO(
                    electionSetup.Id, 
                    electionSetup.ElectionDate, 
                    electionSetup.Description!, 
                    electionSetup.WatermarkId, 
                    electionSetup.CountyId, 
                    electionSetup.BallotSpecsId);
            }
        }
    }
}
