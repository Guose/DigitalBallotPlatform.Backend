using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class PlatformUserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PrimaryPhone { get; set; } = string.Empty;
        public string? SecodaryPhone { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("CountyId")]
        [Required]
        public int CountyId { get; set; }
        public CountyModel County { get; set; } = new CountyModel();

        [ForeignKey("CompanyId")]
        [Required]
        public int CompanyId { get; set; }
        public CompanyModel Company { get; set; } = new CompanyModel();

        [ForeignKey("RoleId")]
        [Required]
        public int RoleId { get; set; }
        public RoleModel Role { get; set; } = new RoleModel();
    }
}
