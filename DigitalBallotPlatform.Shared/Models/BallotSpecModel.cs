using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class BallotSpecModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public float Width { get; set; }
        [Required]
        public int Pages { get; set; }
        public float StubSize { get; set; }
        public bool IsTopStub { get; set; }
        public bool IsDuplex { get; set; } = true;

        [ForeignKey(nameof(MaterialId))]
        [Required]
        public int MaterialId { get; set; }
        public BallotMaterialModel? BallotMaterial { get; set; }

        public ICollection<BallotCategoryModel> BallotCategories { get; set; } = [];
        public ICollection<ElectionSetupModel> Elections { get; set; } = [];
    }
}
