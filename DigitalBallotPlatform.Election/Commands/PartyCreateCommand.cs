using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.Models;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Election.Commands
{
    public class PartyCreateCommand : ICreateCommand<PartyDTO>
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public PartyCreateCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task ExecuteCreateAsync(PartyDTO partyDto)
        {
            using (var context = electionDbContextFactory.Create())
            {
                PartyModel party = await PartyDTO.MapPartyDTO(partyDto);

                await context.Parties.AddAsync(party);
                await context.SaveChangesAsync();
            }
        }
    }
}
