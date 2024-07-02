using System.ComponentModel.DataAnnotations;

namespace DigitalBallotPlatform.Shared.Models
{
    public class CompanyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Fax { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public AddressModel CompanyAddress { get; set; } = new();
        public PlatformUserModel ContactPerson { get; set; } = new();

        public List<BallotMaterialModel> BallotMaterials { get; set; } = [];
        public List<PlatformUserModel> PlatformUsers { get; set; } = [];
        public List<RoleModel> Roles { get; set; } = [];
    }
}
