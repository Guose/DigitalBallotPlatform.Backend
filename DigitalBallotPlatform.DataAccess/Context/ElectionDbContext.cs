using DigitalBallotPlatform.DataAccess.DataHelpers;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BallotCategoryModel> BallotCategories => Set<BallotCategoryModel>();
        public DbSet<BallotMaterialModel> BallotMaterials => Set<BallotMaterialModel>();
        public DbSet<BallotSpecModel> BallotSpecs => Set<BallotSpecModel>();
        public DbSet<ElectionSetupModel> ElectionSetups => Set<ElectionSetupModel>();
        public DbSet<CountyModel> Counties => Set<CountyModel>();
        public DbSet<PartyModel> Parties => Set<PartyModel>();
        public DbSet<WatermarkColorModel> WatermarkColors => Set<WatermarkColorModel>();
        public DbSet<WatermarkModel> Watermarks => Set<WatermarkModel>();
        public DbSet<PlatformUserModel> PlatformUsers => Set<PlatformUserModel>();
        public DbSet<RoleModel> Roles => Set<RoleModel>();
        public DbSet<CompanyModel> Companies => Set<CompanyModel>();
        public DbSet<AddressModel> Addresses => Set<AddressModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ModelCreator();
            modelBuilder.Seed();
        }
    }
}
