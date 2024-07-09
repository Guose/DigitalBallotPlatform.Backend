using DigitalBallotPlatform.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DigitalBallotPlatform.DataAccess.Factory
{
    public class ElectionDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ElectionDbContext>
    {
        public ElectionDbContext CreateDbContext(string[]? args = null)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("SQLElectionDbConnection");

            return new ElectionDbContext(new DbContextOptionsBuilder()
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .Options);
        }
    }
}
