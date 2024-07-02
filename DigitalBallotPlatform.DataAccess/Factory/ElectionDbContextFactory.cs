using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class ElectionDbContextFactory
    {
        private readonly DbContextOptions _options;
        public ElectionDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ElectionDbContext Create()
        {
            return new ElectionDbContext(_options);
        }
    }
}
