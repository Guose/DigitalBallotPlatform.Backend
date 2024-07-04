using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class WatermarkColorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Color { get; set; } = string.Empty;
        public string Tint { get; set; } = string.Empty;
        public string? VdfColor1 { get; set; }
        public string? VdfColor2 { get; set; }
        public string? VdfColor3 { get; set; }
        public List<PartyModel> Parties { get; set; } = new List<PartyModel>();
    }
}
