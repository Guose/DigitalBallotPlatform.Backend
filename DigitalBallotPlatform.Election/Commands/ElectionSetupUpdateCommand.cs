using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Election.Commands
{
    public class ElectionSetupUpdateCommand : IUpdateCommand<ElectionSetupDTO>
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public ElectionSetupUpdateCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task ExecuteUpdateAsync(ElectionSetupDTO electionSetupDto)
        {
            using (var context = electionDbContextFactory.Create())
            {
                ElectionSetupModel electionModel = await ElectionSetupDTO.MapElectionSetupModel(electionSetupDto);

                context.ElectionSetups!.Update(electionModel);
                await context.SaveChangesAsync();
            }
        }
    }
}
