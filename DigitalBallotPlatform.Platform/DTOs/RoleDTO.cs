using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.Platform.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public RoleTypes Role { get; set; }
        public string? Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public int? CompanyId { get; set; }

        public RoleDTO() { }
        public RoleDTO(RoleTypes role, string description,DateTime updatedAt, bool enabled, int companyId)
        {
            Role = role;
            Description = description;
            UpdatedAt = updatedAt;
            Enabled = enabled;
            CompanyId = companyId;
        }

        public static async Task<RoleModel> MapRoleModel(RoleDTO roleDTO)
        {
            return await Task.Run(() => new RoleModel
            {
                Role = roleDTO.Role,
                Description = roleDTO.Description,
                Enabled = roleDTO.Enabled,
            });
        }

        public static async Task<RoleDTO> MapRoleDto(RoleModel role)
        {
            return await Task.Run(() => new RoleDTO
            {
                Id = role.Id,
                Role = role.Role,
                Description = role.Description,
                UpdatedAt = DateTime.Now,
                Enabled = role.Enabled,
            });
        }
    }
}
