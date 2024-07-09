using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class BallotMaterialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Weight { get; set; }
        public bool IsTextWeight { get; set; }

        [Required][ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public CompanyModel? Company { get; set; }
    }
}
