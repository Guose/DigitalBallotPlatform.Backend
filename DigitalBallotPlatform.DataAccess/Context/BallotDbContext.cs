using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class BallotDbContext : DbContext
    {
        public BallotDbContext(DbContextOptions options) : base(options) { }

        DbSet<BallotCategoryModel> BallotCategories => Set<BallotCategoryModel>();
        DbSet<BallotMaterialModel> BallotMaterials => Set<BallotMaterialModel>();
        
    }
}
