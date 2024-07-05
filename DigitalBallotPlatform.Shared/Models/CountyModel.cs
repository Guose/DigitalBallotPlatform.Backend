using DigitalBallotPlatform.Shared.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class CountyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public BallotSystemType BallotTabulation { get; set; }
        
        [Required]
        public VoterSystemType VoterReg { get; set; }

        [Required]
        [ForeignKey(nameof(AddressId))]
        public int AddressId { get; set; }
        public AddressModel CompanyAddress { get; set; } = new();

        public List<PlatformUserModel> PlatformUsers { get; set; } = [];
        public List<ElectionSetupModel> ElectionSetups { get; set; } = [];
    }
}
