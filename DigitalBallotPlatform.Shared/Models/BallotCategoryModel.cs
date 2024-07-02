using DigitalBallotPlatform.Shared.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class BallotCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public BallotCategoryType Category { get; set; } 
        public SubCategoryType? SubCategory { get; set; }
        public LATestDeckType? LARotation { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public bool IsTestdeck { get; set; }
        public bool Enabled { get; set; }

        [ForeignKey("BallotSpecId")]
        [Required]
        public int BallotSpecId { get; set; }
        public BallotSpecModel BallotSpec { get; set; } = new BallotSpecModel();
    }
}
