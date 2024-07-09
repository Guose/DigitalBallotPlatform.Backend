using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.DataAccess.Seeds
{
    public interface ISeedsElectionDb
    {
        List<AddressModel> GetAddressSeeds();
        List<BallotSpecModel> GetBallotSpecSeeds();
        List<BallotCategoryModel> GetBallotCategorySeeds();
        List<BallotMaterialModel> GetBallotMaterialSeeds();
        List<CompanyModel> GetCompanySeeds();
        List<CountyModel> GetCountySeeds();
        List<ElectionSetupModel> GetElectionSetupSeeds();
        List<PartyModel> GetPartySeeds();
        List<PlatformUserModel> GetPlatformUserSeeds();
        List<RoleModel> GetRoleSeeds();
        List<WatermarkColorModel> GetWatermarkColorSeeds();
        List<WatermarkModel> GetWatermarkModelList();
    }
}
