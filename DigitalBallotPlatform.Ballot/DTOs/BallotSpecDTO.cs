using DigitalBallotPlatform.Shared.Models;

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
        public BallotSpecDTO(float length, float width, int pages, float stubSize, bool isTopStub, bool isDuplex, int ballotMaterialId)
        {
            Length = length;
            Width = width;
            Pages = pages;
            StubSize = stubSize;
            IsTopStub = isTopStub;
            IsDuplex = isDuplex;
            BallotMaterialId = ballotMaterialId;
        }

        public static async Task<BallotSpecModel> MapBallotSpecModel(BallotSpecDTO model)
        {
            return await Task.Run(() => new BallotSpecModel
            {
                Length = model.Length,
                Width = model.Width,
                Pages = model.Pages,
                StubSize = model.StubSize,
                IsTopStub = model.IsTopStub,
                IsDuplex = model.IsDuplex,
                MaterialId = model.BallotMaterialId
            });
        }

        public static async Task<BallotSpecDTO> MapBallotSpecDto(BallotSpecModel model)
        {
            return await Task.Run(() => new BallotSpecDTO
            {
                Id = model.Id,
                Length = model.Length,
                Width = model.Width,
                Pages = model.Pages,
                StubSize = model.StubSize,
                IsTopStub = model.IsTopStub,
                IsDuplex = model.IsDuplex,
                BallotMaterialId = model.MaterialId
            });
        }
    }
}
