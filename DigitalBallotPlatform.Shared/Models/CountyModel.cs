using DigitalBallotPlatform.Shared.Types;
using System.ComponentModel.DataAnnotations;

namespace DigitalBallotPlatform.Shared.Models
{
    public class CountyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public BallotSystemType BallotTabulation { get; set; }
        
        [Required]
        public VoterSystemType VoterReg { get; set; }

        public List<PlatformUserModel> PlatformUsers { get; set; } = [];
        public List<ElectionSetupModel> ElectionSetups { get; set; } = [];
    }
}
