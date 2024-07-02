using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.Ballot.DTOs
{
    public class BallotCategoryDTO
    {
        public int Id { get; set; }
        public BallotCategoryType Category { get; set; }
        public SubCategoryType? SubCategory { get; set; }
        public LATestDeckType? LARotation { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsTestdeck { get; set; }
        public bool Enabled { get; set; }
        public int BallotSpecId { get; set; }

        public BallotCategoryDTO() { }
        public BallotCategoryDTO(int id,
            BallotCategoryType category,
            SubCategoryType subCategory,
            LATestDeckType laRotation,
            string description,
            bool isTestdeck,
            bool enabled,
            int ballotSpecId)
        {
            Id = id;
            Category = category;
            SubCategory = subCategory;
            LARotation = laRotation;
            Description = description;
            IsTestdeck = isTestdeck;
            Enabled = enabled;
            BallotSpecId = ballotSpecId;
        }
    }
}
