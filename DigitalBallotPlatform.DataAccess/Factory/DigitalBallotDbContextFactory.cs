using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class DigitalBallotDbContextFactory
    {
        private readonly DbContextOptions _options;

        public DigitalBallotDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public BallotDbContext Create()
        {
            return new BallotDbContext(_options);
        }
    }
}
