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
        public string? Description { get; set; }
        public string? Fax { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Required]
        [ForeignKey(nameof(AddressId))]
        public int AddressId { get; set; }
        public AddressModel CompanyAddress { get; set; } = new();
        [Required]
        [ForeignKey(nameof(ContactId))]
        public int ContactId { get; set; }
        public PlatformUserModel ContactPerson { get; set; } = new();

        public List<BallotMaterialModel> BallotMaterials { get; set; } = [];
        public List<PlatformUserModel> PlatformUsers { get; set; } = [];
        public List<RoleModel> Roles { get; set; } = [];
    }
}
