using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PlatformUserModel> PlatformUsers => Set<PlatformUserModel>();
        public DbSet<RoleModel> Roles => Set<RoleModel>();        
        public DbSet<CompanyModel> Companies => Set<CompanyModel>();
        public DbSet<AddressModel> Addresses => Set<AddressModel>();
    }
}
