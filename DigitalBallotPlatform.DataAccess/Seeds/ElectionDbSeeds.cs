using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.DataAccess.Seeds
{
    public class ElectionDbSeeds : ISeedsElectionDb
    {
        public List<AddressModel> GetAddressSeeds()
        {
            return new List<AddressModel>
            {
                new AddressModel
                {
                    Id = -1,
                    Address1 = "11310 S Lake Stevens Rd",
                    City = "Lake Stevens",
                    State = "Washington",
                    Zipcode = 98258,
                    IsSameAsBilling = true,
                    CompanyId = -1
                },
                new AddressModel
                {
                    Id = -2,
                    Address1 = "7632 SE Douglas Ave",
                    City = "Snoqualmie",
                    State = "Washington",
                    Zipcode = 98065,
                    IsSameAsBilling = false,
                    ShpAddress1 = "11310 S Lake Stevens Rd",
                    ShpCity = "Lake Stevens",
                    ShpState = "WA",
                    ShpZipcode = 98258,
                    CountyId = -2
                }
            };
        }

        public List<BallotSpecModel> GetBallotSpecSeeds()
        {
            return new List<BallotSpecModel>
            {
                new BallotSpecModel
                {
                    Id = -1,
                    Length = 11,
                    Width = 8.5f,
                    Pages = 1,
                    StubSize = 1,
                    IsTopStub = true,
                    IsDuplex = default,
                    MaterialId = -2,
                },
                new BallotSpecModel
                {
                    Id = -2,
                    Length = 14,
                    Width = 8.5f,
                    Pages = 2,
                    StubSize = 1,
                    IsTopStub = true,
                    IsDuplex = default,
                    MaterialId = -1,
                }
            };
        }

        public List<BallotCategoryModel> GetBallotCategorySeeds()
        {
            return new List<BallotCategoryModel>
            {
                new BallotCategoryModel
                {
                    Id = -1,
                    Category = BallotCategoryType.Poll,
                    Description = "Poll Ballot",
                    BallotSpecId = -2,
                },
                new BallotCategoryModel
                {
                    Id = -2,
                    Category = BallotCategoryType.Absentee,
                    Description = "Absentee Ballot",
                    BallotSpecId = -1,
                }
            };
        }

        public List<BallotMaterialModel> GetBallotMaterialSeeds()
        {
            return new List<BallotMaterialModel>
            {
                new BallotMaterialModel
                {
                    Id = -1,
                    Weight = 90,
                    IsTextWeight = true,
                    CompanyId = -1,
                },
                new BallotMaterialModel
                {
                    Id = -2,
                    Weight = 110,
                    IsTextWeight = false,
                    CompanyId = -1,
                }
            };
        }

        public List<CompanyModel> GetCompanySeeds()
        {
            return new List<CompanyModel>
            {
                new CompanyModel
                {
                    Id = -1,
                    Name = "Roland",
                    CreatedAt = DateTime.Now,
                    AddressId = -1
                }
            };
        }

        public List<CountyModel> GetCountySeeds()
        {
            return new List<CountyModel>
            {
                new CountyModel
                {
                    Id = -1,
                    Name = "King County Elections",
                    BallotTabulation = BallotSystemType.ClearBallot,
                    VoterReg = VoterSystemType.SCORE2,
                    AddressId = -2
                }
            };
        }

        public List<ElectionSetupModel> GetElectionSetupSeeds()
        {
            return new List<ElectionSetupModel>()
            {
                new ElectionSetupModel()
                {
                    Id = -1,
                    ElectionDate = new DateTime(2024, 11, 12),
                    Description = "General Election",
                    CountyId = -1,
                    BallotSpecsId = -2,
                }
            };
        }

        public List<PartyModel> GetPartySeeds()
        {
            return new List<PartyModel>
            {
                new PartyModel
                {
                    Id = -1,
                    Name = "Republican",
                    Acronym = "REP",
                    ElectionId = -1,
                },
                new PartyModel
                {
                    Id = -2,
                    Name = "Democrat",
                    Acronym = "DEM",
                    ElectionId = -1,
                },
                new PartyModel
                {
                    Id = -3,
                    Name = "Libertarian",
                    Acronym = "LIB",
                    ElectionId = -1,
                },
            };
        }

        public List<PlatformUserModel> GetPlatformUserSeeds()
        {
            return new List<PlatformUserModel>
            {
                new PlatformUserModel
                {
                    Id = Guid.NewGuid(),
                    Fullname = "Justin Elder",
                    Email = "jjelder79@gmail.com",
                    Username = "Guose",
                    Password = "5p3ctrum",
                    PrimaryPhone = "4259234362",
                    CreatedAt = DateTime.Now,
                    RoleId = -1
                },
                new PlatformUserModel
                {
                    Id = Guid.NewGuid(),
                    Fullname = "Kathleen Lordan-Morris",
                    Email = "cuggle1008@gmail.com",
                    Username = "K-rad",
                    Password = "5p3ctrum",
                    PrimaryPhone = "4258022164",
                    CreatedAt = DateTime.Now,
                    RoleId = -2
                }
            };
        }

        public List<RoleModel> GetRoleSeeds()
        {
            return new List<RoleModel>
            {
                new RoleModel
                {
                    Id = -1,
                    Role = RoleTypes.Admin,
                    Description = RoleTypes.Admin.ToString(),
                    Enabled = true
                },
                new RoleModel
                {
                    Id = -2,
                    Role = RoleTypes.Contributor,
                    Description = RoleTypes.Contributor.ToString(),
                    Enabled = true
                }
            };
        }

        public List<WatermarkColorModel> GetWatermarkColorSeeds()
        {
            return new List<WatermarkColorModel>
            {
                new WatermarkColorModel
                {
                    Id = -1,
                    Tint = "151",
                    Color = "Orange",
                    HasHeaderFill = true,
                },
                new WatermarkColorModel
                {
                    Id = -2,
                    Tint = "543",
                    Color = "Blue",
                    HasHeaderFill = false,
                },
                new WatermarkColorModel
                {
                    Id = -3,
                    Tint = "465",
                    Color = "Brown",
                    HasHeaderFill = true,
                },
            };
        }

        public List<WatermarkModel> GetWatermarkModelList()
        {
            return new List<WatermarkModel>
            {
                new WatermarkModel
                {
                    Id = -1,
                    Name = "CAOutline"
                },
                new WatermarkModel
                {
                    Id = -2,
                    Name = "CASeal"
                }
            };
        }
    }
}
