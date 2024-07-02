using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class PlatformDbContextFactory
    {
        private readonly DbContextOptions _options;

        public PlatformDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public PlatformDbContext Create()
        {
            return new PlatformDbContext(_options);
        }
    }
}
