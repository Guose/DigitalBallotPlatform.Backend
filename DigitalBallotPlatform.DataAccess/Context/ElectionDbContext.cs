using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.Context
{
    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext(DbContextOptions options) : base(options) { }

        DbSet<CountyModel> Counties => Set<CountyModel>();
        DbSet<BallotSpecModel> BallotSpecs => Set<BallotSpecModel>();
        DbSet<PartyModel> Parties => Set<PartyModel>();
        DbSet<WatermarkColorModel> WatermarkColors => Set<WatermarkColorModel>();
        DbSet<WatermarkModel> Watermarks => Set<WatermarkModel>();
    }
}
