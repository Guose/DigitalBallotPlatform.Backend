using DigitalBallotPlatform.Shared.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class RoleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public RoleTypes Role { get; set; }
        public string? Description { get; set; }
        public bool Enabled { get; set; }
                
        public ICollection<PlatformUserModel> PlatformUsers { get; set; } = [];
    }
}
