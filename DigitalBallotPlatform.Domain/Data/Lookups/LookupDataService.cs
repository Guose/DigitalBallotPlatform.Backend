using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public class LookupDataService : IElectionSetupLookupDataService, IPartyLookupDataService, IBallotCategoryLookupDataService,
        IBallotMaterialLookupDataService, IBallotSpecsLookupDataService, ICompanyLookupDataService, ICountyLookupDataService,
        IPlatformUserLookupDataService, IRoleLookupDataService, IWatermarkColorLookupDataService, IWatermarkLookupDataService
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

        public async Task<IEnumerable<LookupItem>> GetBallotCategoryLookupAsync()
        {
            using var ctx = ballotContextCreator();
            return await ctx.BallotCategories.AsNoTracking()
                .Select(b => new LookupItem
                {
                    Id = b.Id,
                    DisplayMember = b.Category.ToString()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetBallotMaterialLookupAsync()
        {
            using var ctx = ballotContextCreator();
            return await ctx.BallotMaterials.AsNoTracking()
                .Select(b => new LookupItem
                {
                    Id= b.Id,
                    DisplayMember = b.IsTextWeight == true ? $"{b.Weight}# Text" : $"{b.Weight}# Index",
                })
                .ToListAsync();
        }

        public Task<IEnumerable<LookupItem>> GetBallotSpecsLookupAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupItem>> GetCompanyLookupAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupItem>> GetCountyLookupAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LookupItem>> GetElectionLookupAsync()
        {
            using var ctx = electionContextCreator();
            return await ctx.ElectionSetups.AsNoTracking()
                .Select(e =>
                new LookupItem
                {
                    Id = e.Id,
                    DisplayMember = $"{e.ElectionDate} - {e.Description}"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetPartyLookupAsync()
        {
            using var ctx = electionContextCreator();
            return await ctx.Parties.AsNoTracking()
                .Select(p =>
                new LookupItem
                {
                    Id = p.Id,
                    DisplayMember = p.Acronym
                })
                .ToListAsync();
        }

        public Task<IEnumerable<LookupItem>> GetPlatformUserLookupAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupItem>> GetRoleLookupAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupItem>> GetWatermarkColorLookupAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LookupItem>> GetWatermarkLookupAsync()
        {
            throw new NotImplementedException();
        }
    }
}
