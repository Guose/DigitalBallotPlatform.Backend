using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Company.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Description { get; set; }
        public int AddressId { get; set; }

        public CompanyDTO() { }
        public CompanyDTO(string name, string description, string? contactPerson, int addressId)
        {
            Name = name;
            Description = description;
            ContactPerson = contactPerson;
            AddressId = addressId;
        }

        public static async Task<CompanyDTO> MapCompanyDto(CompanyModel company)
        {
            return await Task.Run(() => new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                AddressId = company.AddressId,
            });
        }

        public static async Task<CompanyModel> MapCompanyModel(CompanyDTO companyDto)
        {
            return await Task.Run(() => new CompanyModel
            {
                Name = companyDto.Name,
                Description = companyDto.Description,
                AddressId = companyDto.AddressId
            });
        }
    }
}
