using DigitalBallotPlatform.DataAccess.Context;

namespace DigitalBallotPlatform.Domain.Data.Lookups
{
    public class LookupDataService
    {
        private Func<BallotDbContext> ballotContextCreator;
        private Func<ElectionDbContext> electionContextCreator;
        private Func<PlatformDbContext> platformContextCreator;

        public LookupDataService(
            Func<BallotDbContext> ballotContextCreator,
            Func<ElectionDbContext> electionContextCreator,
            Func<PlatformDbContext> platformContextCreator)
        {
            this.ballotContextCreator = ballotContextCreator;
            this.electionContextCreator = electionContextCreator;
            this.platformContextCreator = platformContextCreator;
        }
    }
}
