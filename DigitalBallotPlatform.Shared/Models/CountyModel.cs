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
        public AddressModel? Address { get; set; }

        public ICollection<PlatformUserModel> PlatformUsers { get; set; } = [];
        public ICollection<ElectionSetupModel> ElectionSetups { get; set; } = [];
        public ICollection<RoleModel> Roles { get; set; } = [];
    }
}
