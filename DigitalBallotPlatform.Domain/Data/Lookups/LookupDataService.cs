using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Shared.Models;
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
                    Id = b.Id,
                    DisplayMember = b.IsTextWeight == true ? $"{b.Company.Name} {b.Weight}# Text" : $"{b.Company.Name} {b.Weight}# Index",
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetBallotSpecsLookupAsync()
        {
            using var ctx = ballotContextCreator();
            return await ctx.BallotSpecs.AsNoTracking()
                .Select(b => new LookupItem()
                {
                    Id = b.Id,
                    DisplayMember = "Ballot Specs"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetCompanyLookupAsync()
        {
            using var ctx = platformContextCreator();
            return await ctx.Companies.AsNoTracking()
                .Select(c => new LookupItem
                {
                    Id = c.Id,
                    DisplayMember = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetCountyLookupAsync()
        {
            using var ctx = electionContextCreator();
            return await ctx.Counties.AsNoTracking()
                .Select(c => new LookupItem
                {
                    Id = c.Id,
                    DisplayMember = c.Name
                })
                .ToListAsync();
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

        public async Task<IEnumerable<LookupItem>> GetPlatformUserLookupAsync()
        {
            using var ctx = platformContextCreator();
            return await ctx.PlatformUsers.AsNoTracking()
                .Select(u => new LookupItem
                {
                    UserId = u.Id,
                    DisplayMember = u.Fullname,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetRoleLookupAsync()
        {
            using var ctx = platformContextCreator();
            return await ctx.Roles.AsNoTracking()
                .Select(r => new LookupItem
                {
                    Id = r.Id,
                    DisplayMember = r.Role.ToString()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetWatermarkColorLookupAsync()
        {
            using var ctx = electionContextCreator();
            return await ctx.WatermarkColors.AsNoTracking()
                .Select(wc => new LookupItem
                {
                    Id = wc.Id,
                    DisplayMember = $"{wc.Tint}{wc.Color}"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetWatermarkLookupAsync()
        {
            using var ctx = electionContextCreator();
            return await ctx.Watermarks.AsNoTracking()
                .Select(w => new LookupItem
                {
                    Id = w.Id,
                    DisplayMember = w.Name
                })
                .ToListAsync();
        }
    }
}
