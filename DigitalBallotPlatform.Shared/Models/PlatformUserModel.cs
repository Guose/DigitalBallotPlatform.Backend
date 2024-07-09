using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class PlatformUserModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Fullname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string? PrimaryPhone { get; set; }
        [Phone]
        public string? SecodaryPhone { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(CountyId))]
        public int? CountyId { get; set; }
        public CountyModel? County { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public int? CompanyId { get; set; }
        public CompanyModel? Company { get; set; }

        [ForeignKey(nameof(RoleId))]
        [Required]
        public int RoleId { get; set; }
        public RoleModel? Role { get; set; }
    }
}
