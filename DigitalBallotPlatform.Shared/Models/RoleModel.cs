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

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }

        [Required]
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public CompanyModel Company { get; set; } = new CompanyModel();
        public ICollection<PlatformUserModel> PlatformUsers { get; set; } = [];
    }
}
