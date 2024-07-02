namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotSpecDTO
    {
        public int Id { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public int Pages { get; set; }
        public float StubSize { get; set; }
        public bool IsTopStub { get; set; }
        public bool IsDuplex { get; set; }
        public int BallotMaterialId { get; set; }
        public List<BallotCategoryDTO> BallotCategories { get; set; } = [];

        public BallotSpecDTO() { }
        public BallotSpecDTO(int id, float length, float width, int pages, float stubSize, bool isTopStub, bool isDuplex, int ballotMaterialId)
        {
            Id = id;
            Length = length;
            Width = width;
            Pages = pages;
            StubSize = stubSize;
            IsTopStub = isTopStub;
            IsDuplex = isDuplex;
            BallotMaterialId = ballotMaterialId;
        }
    }
}
