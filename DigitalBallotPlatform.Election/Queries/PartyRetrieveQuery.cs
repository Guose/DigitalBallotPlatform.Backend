using DigitalBallotPlatform.DataAccess.Factory;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Interfaces.Queries;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB;

namespace DigitalBallotPlatform.Election.Queries
{
    public class PartyRetrieveQuery : IRetrieveQuery<PartyDTO>
    {
        private readonly ElectionDbContextFactory electionDbContextFactory;

        public PartyRetrieveQuery(ElectionDbContextFactory electionDbContextFactory)
        {
            this.electionDbContextFactory = electionDbContextFactory;
        }

        public async Task<IEnumerable<PartyDTO>> GetAllEntitiesAsync()
        {
            using (var context = electionDbContextFactory.Create())
            {
                IEnumerable<PartyModel> parties = await context.Parties!.ToListAsync();

                return parties.Select(p => new PartyDTO(p.Id, p.Name, p.Acronym, (int)p.ElectionId!));
            }
        }

        public async Task<PartyDTO> GetEntityByIdAsync(int id)
        {
            using (var context = electionDbContextFactory.Create())
            {
                PartyModel party = await context.Parties.FirstAsync(p => p.Id == id);

                return new PartyDTO(party.Id, party.Name, party.Acronym, (int)party.ElectionId!);
            }
        }
    }
}
