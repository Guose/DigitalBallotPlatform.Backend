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
        public bool HasHeaderFill { get; set; } = false;
        public List<PartyModel> Parties { get; set; } = new List<PartyModel>();
    }
}
