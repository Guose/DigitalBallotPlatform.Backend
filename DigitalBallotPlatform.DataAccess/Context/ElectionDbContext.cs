using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ElectionSetupModel> ElectionSetups => Set<ElectionSetupModel>();
        public DbSet<CountyModel> Counties => Set<CountyModel>();
        public DbSet<PartyModel> Parties => Set<PartyModel>();
        public DbSet<WatermarkColorModel> WatermarkColors => Set<WatermarkColorModel>();
        public DbSet<WatermarkModel> Watermarks => Set<WatermarkModel>();
    }
}
