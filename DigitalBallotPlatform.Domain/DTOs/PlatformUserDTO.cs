namespace DigitalBallotPlatform.Domain.DTOs
{
    public class PlatformUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PrimaryPhone { get; set; } = string.Empty;
        public string? SecodaryPhone { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CountyId { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

        public PlatformUserDTO(int id, 
            string name, 
            string email, 
            string username, 
            string password, 
            string primaryPhone, 
            string secondaryPhone,
            DateTime updatedAt,
            int countyId,
            int companyId,
            int roleId)
        {
            Id = id; 
            Name = name; 
            Email = email;
            Username = username;
            Password = password;
            PrimaryPhone = primaryPhone;
            SecodaryPhone = secondaryPhone;
            UpdatedAt = updatedAt;
            CountyId = countyId;
            CompanyId = companyId;
            RoleId = roleId;
        }
    }
}
