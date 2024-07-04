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
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }

        [Required]
        [ForeignKey(nameof(CompanyId))]
        public int CompanyId { get; set; }
        public CompanyModel Company { get; set; } = new CompanyModel();
        public List<PlatformUserModel> PlatformUsers { get; set; } = new List<PlatformUserModel>();
    }
}
