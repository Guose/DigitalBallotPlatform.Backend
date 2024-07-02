using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.DataAccess.Factory;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.DataHelpers
{
    public class DbContextServiceHelper
    {
        private readonly DigitalBallotDbContextFactory _digitalBallotCtxFactory;
        private readonly ElectionDbContextFactory _electionSetupCtxFactory;
        private readonly PlatformDbContextFactory _platformCtxFactory;

        public DbContextServiceHelper(
            DigitalBallotDbContextFactory digitalBallotCtxFactory, 
            ElectionDbContextFactory electionSetupCtxFactory,
            PlatformDbContextFactory platformCtxFactory)
        {
            _digitalBallotCtxFactory = digitalBallotCtxFactory;
            _electionSetupCtxFactory = electionSetupCtxFactory;
            _platformCtxFactory = platformCtxFactory;

        }

        public async Task MigrateDatabaseAsync()
        {
            using BallotDbContext ballotCtx = _digitalBallotCtxFactory.Create();
            await ballotCtx.Database.MigrateAsync();

            using ElectionDbContext electionCtx = _electionSetupCtxFactory.Create();
            await electionCtx.Database.MigrateAsync();

            using PlatformDbContext platformCtx = _platformCtxFactory.Create();
            await platformCtx.Database.MigrateAsync();
        }
    }
}
