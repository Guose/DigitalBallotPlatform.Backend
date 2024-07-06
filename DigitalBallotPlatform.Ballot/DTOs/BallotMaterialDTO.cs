using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotMaterialDTO
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public bool IsTextWeight { get; set; }
        public int CompanyId { get; set; }

        public BallotMaterialDTO() { }
        public BallotMaterialDTO(int id, int weight, bool isTextWeight, int companyId)
        {
            Id = id;
            Weight = weight;
            IsTextWeight = isTextWeight;
            CompanyId = companyId;
        }

        public static async Task<BallotMaterialModel> MapBallotMaterialModel(BallotMaterialDTO ballotMaterialsDto)
        {
            return await Task.Run(() => new BallotMaterialModel
            {
                Id = ballotMaterialsDto.Id,
                Weight = ballotMaterialsDto.Weight,
                IsTextWeight = ballotMaterialsDto.IsTextWeight,
                CompanyId = ballotMaterialsDto.CompanyId
            });
        }

        public static async Task<BallotMaterialDTO> MapBallotMaterialDto(BallotMaterialModel ballotMaterial)
        {
            return await Task.Run(() => new BallotMaterialDTO
            {
                Id = ballotMaterial.Id,
                Weight = ballotMaterial.Weight,
                IsTextWeight = ballotMaterial.IsTextWeight,
                CompanyId = ballotMaterial.CompanyId
            });
        }
    }
}
