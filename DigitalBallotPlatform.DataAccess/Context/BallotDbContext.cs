using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class BallotDbContext : DbContext
    {
        public BallotDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BallotCategoryModel> BallotCategories => Set<BallotCategoryModel>();
        public DbSet<BallotMaterialModel> BallotMaterials => Set<BallotMaterialModel>();
        public DbSet<BallotSpecModel> BallotSpecs => Set<BallotSpecModel>();
    }
}
