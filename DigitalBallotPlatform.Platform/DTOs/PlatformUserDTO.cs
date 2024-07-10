using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Platform.DTOs
{
    public class PlatformUserDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? PrimaryPhone { get; set; } = string.Empty;
        public string? SecodaryPhone { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CountyId { get; set; }
        public int? CompanyId { get; set; }
        public int RoleId { get; set; }

        public PlatformUserDTO() { }
        public PlatformUserDTO( 
            string firstName, 
            string lastName,
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
            Firstname = firstName;
            Lastname = lastName;
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

        public static async Task<PlatformUserModel> MapPlatformUserModel(PlatformUserDTO userDto)
        {
            return await Task.Run(() => new PlatformUserModel
            {
                Fullname = $"{userDto.Firstname} {userDto.Lastname}",
                Email = userDto.Email,
                Username = userDto.Username,
                Password = userDto.Password,
                PrimaryPhone = userDto.PrimaryPhone,
                UpdatedAt = userDto.UpdatedAt,
                CountyId = userDto.CountyId,
                CompanyId = userDto.CompanyId,
                RoleId = userDto.RoleId
            });
        }

        public static async Task<PlatformUserDTO> MapPlatformUserDto(PlatformUserModel userModel)
        {
            string[] names = userModel.Fullname.Split(' ');
            return await Task.Run(() => new PlatformUserDTO
            {
                Id = userModel.Id,
                Firstname = names[0],
                Lastname = names[1],
                Email = userModel.Email,
                Username = userModel.Username,
                Password = userModel.Password,
                PrimaryPhone = userModel.PrimaryPhone,
                UpdatedAt = userModel.UpdatedAt,
                CountyId = userModel.CountyId,
                CompanyId = userModel.CompanyId,
                RoleId = userModel.RoleId
            });
        }
    }
}
