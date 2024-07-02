using System.ComponentModel.DataAnnotations;

namespace DigitalBallotPlatform.Shared.Models
{
    public class WatermarkModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;

        public List<PartyModel> Parties { get; set; } = new List<PartyModel>();
    }
}
