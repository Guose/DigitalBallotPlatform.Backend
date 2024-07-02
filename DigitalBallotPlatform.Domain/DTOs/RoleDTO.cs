namespace DigitalBallotPlatform.Shared.DTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Enabled { get; set; }
        public int CompanyId { get; set; }

        public RoleDTO(int id, string name, string description,DateTime updatedAt, bool enabled, int companyId)
        {
            Id = id;
            Name = name;
            Description = description;
            UpdatedAt = updatedAt;
            Enabled = enabled;
            CompanyId = companyId;
        }
    }
}
