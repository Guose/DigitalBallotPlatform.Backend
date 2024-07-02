using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class PlatformDesignTimeDbContextFactory : IDesignTimeDbContextFactory<PlatformDbContext>
    {
        public PlatformDbContext CreateDbContext(string[] args)
        {
            return new PlatformDbContext(
                new DbContextOptionsBuilder().UseSqlite("Data Source=DigitalPlatform.db").Options);
        }
    }
}
