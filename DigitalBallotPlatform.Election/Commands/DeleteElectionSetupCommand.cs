using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB;

namespace DigitalBallotPlatform.Election.Commands
{
    public class DeleteElectionSetupCommand : IDeleteCommand
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public DeleteElectionSetupCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task<bool> ExecuteDeleteAsync(int id)
        {
            using (var context = electionDbContextFactory.Create())
            {
                ElectionSetupModel electionSetup = await context.ElectionSetups.FirstAsync(e => e.Id == id);

                if (electionSetup != null)
                {
                    context.ElectionSetups.Remove(electionSetup);
                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }
    }
}
