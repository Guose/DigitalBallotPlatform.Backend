using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public class LookupDataService : IElectionSetupLookupDataService, IPartyLookupDataService
    {
        private readonly Func<BallotDbContext> ballotContextCreator;
        private readonly Func<ElectionDbContext> electionContextCreator;
        private readonly Func<PlatformDbContext> platformContextCreator;

        public LookupDataService(
            Func<BallotDbContext> ballotContextCreator,
            Func<ElectionDbContext> electionContextCreator,
            Func<PlatformDbContext> platformContextCreator)
        {
            this.ballotContextCreator = ballotContextCreator;
            this.electionContextCreator = electionContextCreator;
            this.platformContextCreator = platformContextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetElectionLookupAsync()
        {
            using (var ctx = electionContextCreator())
            {
                return await ctx.ElectionSetups.AsNoTracking()
                    .Select(e =>
                    new LookupItem
                    {
                        Id = e.Id,
                        DisplayMember = $"{e.ElectionDate} - {e.Description}"
                    })
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<LookupItem>> GetPartyLookupAsync()
        {
            using (var ctx = electionContextCreator())
            {
                return await ctx.Parties.AsNoTracking()
                    .Select(p =>
                    new LookupItem
                    {
                        Id = p.Id,
                        DisplayMember = p.Acronym
                    })
                    .ToListAsync();
            }
        }
    }
}
