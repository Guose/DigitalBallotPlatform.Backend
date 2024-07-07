using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBallotPlatform.Shared.Models
{
    public class CompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public AddressModel Address { get; set; } = new();
        public ICollection<BallotMaterialModel> BallotMaterials { get; set; } = [];
        public ICollection<PlatformUserModel> PlatformUsers { get; set; } = [];
        public ICollection<RoleModel> Roles { get; set; } = [];
    }
}
