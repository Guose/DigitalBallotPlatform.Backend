using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext(DbContextOptions options) : base(options) { }

        DbSet<PlatformUserModel> PlatformUsers => Set<PlatformUserModel>();
        DbSet<RoleModel> Roles => Set<RoleModel>();        
        DbSet<CompanyModel> Companies => Set<CompanyModel>();
        DbSet<AddressModel> Addresses => Set<AddressModel>();
    }
}
