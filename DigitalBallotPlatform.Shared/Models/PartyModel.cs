using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class PartyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Acronym { get; set; } = string.Empty;
        public string? Abbreviations { get; set; }

        [ForeignKey(nameof(ElectionId))]
        public int? ElectionId { get; set; }
        public ElectionSetupModel? Election { get; set; }

        [ForeignKey(nameof(WatermarkColorId))]
        public int? WatermarkColorId { get; set; }
        public WatermarkColorModel? WatermarkColor { get; set; }
    }
}
