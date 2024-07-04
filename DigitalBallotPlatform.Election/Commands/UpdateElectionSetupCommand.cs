using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB;

namespace DigitalBallotPlatform.Election.Commands
{
    public class UpdateElectionSetupCommand : IUpdateCommand<ElectionSetupDTO>
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public UpdateElectionSetupCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task ExecuteUpdateAsync(ElectionSetupDTO electionSetupDto)
        {
            using (var context = electionDbContextFactory.Create())
            {
                ElectionSetupModel electionModel = await ElectionSetupDTO.MapElectionSetupDTO(electionSetupDto);

                context.ElectionSetups!.Update(electionModel);
                await context.SaveChangesAsync();
            }
        }
    }
}
