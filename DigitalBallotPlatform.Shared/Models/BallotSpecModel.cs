using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class BallotSpecModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public int Sides { get; set; }
        public float StubSize { get; set; }
        public bool IsTopStub { get; set; }

        [ForeignKey(nameof(MaterialId))]
        [Required]
        public int MaterialId { get; set; }
        public BallotMaterialModel? BallotMaterial { get; set; }

        public List<BallotCategoryModel> BallotCategories { get; set; } = new List<BallotCategoryModel>();
        public List<ElectionSetupModel> Elections { get; set; } = new List<ElectionSetupModel>();
    }
}
