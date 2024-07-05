using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.Models;
using DigitalBallotPlatform.Shared.Interfaces.Commands;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Election.Commands
{
    public class PartyUpdateCommand : IUpdateCommand<PartyDTO>
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public PartyUpdateCommand(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task ExecuteUpdateAsync(PartyDTO partyDto)
        {
            using (var context = electionDbContextFactory.Create())
            {
                PartyModel party = await PartyDTO.MapPartyDTO(partyDto);

                context.Parties!.Update(party);
                await context.SaveChangesAsync();
            }
        }
    }
}
