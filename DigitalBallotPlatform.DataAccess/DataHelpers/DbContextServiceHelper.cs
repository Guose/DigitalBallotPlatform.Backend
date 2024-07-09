using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.DataAccess.Factory;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.DataHelpers
{
    public class DbContextServiceHelper
    {
        private readonly ElectionDbContextFactory _electionSetupCtxFactory;

        public DbContextServiceHelper(ElectionDbContextFactory electionSetupCtxFactory)
        {
            _electionSetupCtxFactory = electionSetupCtxFactory;
        }

        public async Task MigrateDatabaseAsync()
        {
            using ElectionDbContext electionCtx = _electionSetupCtxFactory.Create();
            await electionCtx.Database.MigrateAsync();
        }
    }
}
