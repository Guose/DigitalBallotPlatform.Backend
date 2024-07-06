using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB;

namespace DigitalBallotPlatform.Election.Commands
{
    public class PartyDeleteCommand : IDeleteCommand
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public PartyDeleteCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task<bool> ExecuteDeleteAsync(int id)
        {
            using (var context = electionDbContextFactory.Create())
            {
                PartyModel party = await context.Parties.FirstAsync(p => p.Id == id);

                if (party != null)
                {
                    context.Parties.Remove(party);
                    await context.SaveChangesAsync();
                    return true;
                }

                return false;
            }
        }
    }
}
