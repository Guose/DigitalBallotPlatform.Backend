using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Election.Commands
{
    public class CreateElectionSetupCommand : ICreateCommand<ElectionSetupDTO>
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public CreateElectionSetupCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task ExecuteCreateAsync(ElectionSetupDTO electionSetupDto)
        {
            using (var context = electionDbContextFactory.Create())
            {
                ElectionSetupModel electionSetupModel = await ElectionSetupDTO.MapElectionSetupDTO(electionSetupDto);

                await context.ElectionSetups.AddAsync(electionSetupModel);
                await context.SaveChangesAsync();
            }
        }
    }
}
