using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotCategoryDTO
    {
        public int Id { get; set; }
        public BallotCategoryType Category { get; set; }
        public SubCategoryType? SubCategory { get; set; } = 0;
        public LATestDeckType? LARotation { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsTestdeck { get; set; }
        public bool Enabled { get; set; }
        public int BallotSpecId { get; set; }

        public BallotCategoryDTO() { }
        public BallotCategoryDTO(
            BallotCategoryType category,
            SubCategoryType subCategory,
            LATestDeckType laRotation,
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
                Category = ballotCategoryDto.Category,
                SubCategory = ballotCategoryDto.SubCategory,
                LARotation = ballotCategoryDto.LARotation,
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
                Category = ballotCategory.Category,
                SubCategory = ballotCategory.SubCategory,
                LARotation = ballotCategory.LARotation,
                Description = ballotCategory.Description,
                IsTestdeck = ballotCategory.IsTestdeck,
                Enabled = ballotCategory.Enabled,
                BallotSpecId = ballotCategory.BallotSpecId
            });
        }
    }
}
