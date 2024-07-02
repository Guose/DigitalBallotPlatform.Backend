namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotSpecDTO
    {
        public int Id { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public int Sides { get; set; }
        public float StubSize { get; set; }
        public bool IsTopStub { get; set; }
        public int BallotMaterialId { get; set; }

        public BallotSpecDTO(int id, float length, float width, int sides, float stubSize, bool isTopStub, int ballotMaterialId)
        {
            Id = id;
            Length = length;
            Width = width;
            Sides = sides;
            StubSize = stubSize;
            IsTopStub = isTopStub;
            BallotMaterialId = ballotMaterialId;
        }
    }
}
