namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotMaterialDTO
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public bool IsTextWeight { get; set; }
        public int CompanyId { get; set; }

        public BallotMaterialDTO(int id, int weight, bool isTextWeight, int companyId)
        {
            Id = id;
            Weight = weight;
            IsTextWeight = isTextWeight;
            CompanyId = companyId;
        }
    }
}
