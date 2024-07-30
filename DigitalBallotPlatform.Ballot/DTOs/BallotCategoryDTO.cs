using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotCategoryDTO
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? SubCategory { get; set; }
        public string? LARotation { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsTestdeck { get; set; }
        public bool Enabled { get; set; }
        public int BallotSpecId { get; set; }

        public BallotCategoryDTO() { }
        public BallotCategoryDTO(
            string category,
            string subCategory,
            string laRotation,
            string description,
            bool isTestdeck,
            bool enabled,
            int ballotSpecId)
        {
            Category = category;
            SubCategory = subCategory;
            LARotation = laRotation;
            Description = description;
            IsTestdeck = isTestdeck;
            Enabled = enabled;
            BallotSpecId = ballotSpecId;
        }

        public static async Task<BallotCategoryModel> MapBallotCategoryModel(BallotCategoryDTO ballotCategoryDto)
        {
            return await Task.Run(() => new BallotCategoryModel
            {
                Category = (BallotCategoryType)Enum.Parse(typeof(BallotCategoryType), ballotCategoryDto.Category),
                SubCategory = (SubCategoryType)Enum.Parse(typeof(SubCategoryType), ballotCategoryDto.SubCategory!),
                LARotation = (LATestDeckType)Enum.Parse(typeof(LATestDeckType), ballotCategoryDto.LARotation!),
                Description = ballotCategoryDto.Description,
                IsTestdeck = ballotCategoryDto.IsTestdeck,
                Enabled = ballotCategoryDto.Enabled,
                BallotSpecId = ballotCategoryDto.BallotSpecId
            });
        }

        public static async Task<BallotCategoryDTO> MapBallotCategoryDto(BallotCategoryModel ballotCategory)
        {
            return await Task.Run(() => new BallotCategoryDTO
            {
                Id = ballotCategory.Id,
                Category = ballotCategory.Category.ToString(),
                SubCategory = ballotCategory.SubCategory.ToString(),
                LARotation = ballotCategory.LARotation.ToString(),
                Description = ballotCategory.Description,
                IsTestdeck = ballotCategory.IsTestdeck,
                Enabled = ballotCategory.Enabled,
                BallotSpecId = ballotCategory.BallotSpecId
            });
        }
    }
}
