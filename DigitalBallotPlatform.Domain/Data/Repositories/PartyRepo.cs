using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Election.Models;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class PartyRepo : GenericRepository<PartyDTO, ElectionDbContext>, IPartyRepo
    {
        private readonly ILogger logger;

        public PartyRepo(ElectionDbContext context, ILogger logger) : base(context)
        {
            this.logger = logger;
        }

        public async Task<bool> ExecuteUpdateAsync(PartyDTO partyDto)
        {
            try
            {
                PartyModel? party = await Context.Parties.FirstOrDefaultAsyncEF(p => p.Id == partyDto.Id);
                if (party == null)
                    return false;

                party = await PartyDTO.MapPartyModel(partyDto);

                Context.Parties.Update(party);
                await SaveAsync();

                logger.LogInformation("[INFO] {1} Message: Election ID {0} has been updated", party.Id, nameof(ExecuteUpdateAsync));

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<PartyDTO?> GetElectionByIdAsync(int id)
        {
            try
            {
                PartyModel? party = await Context.Parties.FirstOrDefaultAsyncEF(p => p.Id == id);

                if (party != null)
                    return await PartyDTO.MapPartyDTO(party);

                return null;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
