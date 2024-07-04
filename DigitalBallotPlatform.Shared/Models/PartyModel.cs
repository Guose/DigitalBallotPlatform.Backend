using DigitalBallotPlatform.Shared.Types;
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
        [Required]
        public string Abbreviations { get; set; } = string.Empty;
        public WatermarkType? WatermarkType { get; set; }


        public int? ColorId { get; set; }
        public WatermarkColorModel? Color { get; set; }
        public int? ElectionId { get; set; }
        public ElectionSetupModel? Election { get; set; }
    }
}
