using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class DigitalBallotDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BallotDbContext>
    {
        public BallotDbContext CreateDbContext(string[]? args = null)
        {
            return new BallotDbContext(
                new DbContextOptionsBuilder().UseSqlite("Data Source=BallotPlatform.db").Options);
        }
    }
}
