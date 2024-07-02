using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class ElectionDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ElectionDbContext>
    {
        public ElectionDbContext CreateDbContext(string[]? args = null)
        {
            return new ElectionDbContext(
                new DbContextOptionsBuilder().UseSqlite("Data Source=ElectionSetup.db").Options);
        }
    }
}
