using DigitalBallotPlatform.DataAccess.Seeds;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBallotPlatform.DataAccess.DataHelpers
{
    public static class DbContextModelBuildExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var seeds = new ElectionDbSeeds();

            modelBuilder.Entity<AddressModel>().HasData(seeds.GetAddressSeeds());
            modelBuilder.Entity<RoleModel>().HasData(seeds.GetRoleSeeds());
            modelBuilder.Entity<CompanyModel>().HasData(seeds.GetCompanySeeds());
            modelBuilder.Entity<CountyModel>().HasData(seeds.GetCountySeeds());
            modelBuilder.Entity<BallotMaterialModel>().HasData(seeds.GetBallotMaterialSeeds());
            modelBuilder.Entity<BallotSpecModel>().HasData(seeds.GetBallotSpecSeeds());
            modelBuilder.Entity<BallotCategoryModel>().HasData(seeds.GetBallotCategorySeeds());
            modelBuilder.Entity<WatermarkColorModel>().HasData(seeds.GetWatermarkColorSeeds());
            modelBuilder.Entity<WatermarkModel>().HasData(seeds.GetWatermarkModelList());
            modelBuilder.Entity<ElectionSetupModel>().HasData(seeds.GetElectionSetupSeeds());
            modelBuilder.Entity<PartyModel>().HasData(seeds.GetPartySeeds());
            modelBuilder.Entity<PlatformUserModel>().HasData(seeds.GetPlatformUserSeeds());
        }

        public static void ModelCreator(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>()
                .HasOne(a => a.Company)
                .WithOne(c => c.Address)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<CompanyModel>(a => a.AddressId);

            modelBuilder.Entity<AddressModel>()
                .HasOne(a => a.County)
                .WithOne(c => c.Address)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<CountyModel>(a => a.AddressId);

            modelBuilder.Entity<BallotCategoryModel>()
                .HasOne(s => s.BallotSpec)
                .WithMany(c => c.BallotCategories)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s => s.BallotSpecId);

            modelBuilder.Entity<BallotSpecModel>()
                .HasMany(b => b.Elections)
                .WithOne(e => e.BallotSpec)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.BallotSpecsId);

            modelBuilder.Entity<ElectionSetupModel>()
                .HasOne(e => e.Watermark)
                .WithMany(w => w.Elections)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.WatermarkId);

            modelBuilder.Entity<ElectionSetupModel>()
                .HasOne(e => e.County)
                .WithMany(c => c.ElectionSetups)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.CountyId);

            modelBuilder.Entity<ElectionSetupModel>()
                .HasOne(e => e.BallotSpec)
                .WithMany(b => b.Elections)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(e => e.BallotSpecsId);

            modelBuilder.Entity<PartyModel>()
                .HasOne(p => p.Election)
                .WithMany(e => e.Parties)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.ElectionId);

            modelBuilder.Entity<PartyModel>()
                .HasOne(p => p.WatermarkColor)
                .WithMany(w => w.Parties)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.WatermarkColorId);

            modelBuilder.Entity<PlatformUserModel>()
                .HasOne(u => u.Company)
                .WithMany(c => c.PlatformUsers)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<PlatformUserModel>()
                .HasOne(u => u.County)
                .WithMany(c => c.PlatformUsers)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(u => u.CountyId);

            modelBuilder.Entity<PlatformUserModel>()
                .HasOne(u => u.Role)
                .WithMany(r => r.PlatformUsers)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(u => u.RoleId);

            
        }
    }
}
