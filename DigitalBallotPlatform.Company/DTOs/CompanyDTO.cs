using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Company.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Fax { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int AddressId { get; set; }
        public int ContactId { get; set; }

        public CompanyDTO() { }
        public CompanyDTO(int id, string name, string description, string fax, DateTime updatedAt, int addressId, int contactId)
        {
            Id = id;
            Name = name;
            Description = description;
            Fax = fax;
            UpdatedAt = updatedAt;
            AddressId = addressId;
            ContactId = contactId;
        }

        public static async Task<CompanyDTO> MapCompanyDto(CompanyModel company)
        {
            return await Task.Run(() => new CompanyDTO
            {
                Id = company.Id,
                Name = company.Name,
                Description = company.Description,
                Fax = company.Fax,
                UpdatedAt = company.UpdatedAt,
                AddressId = company.AddressId,
                ContactId = company.ContactId,
            });
        }

        public static async Task<CompanyModel> MapCompanyModel(CompanyDTO companyDto)
        {
            return await Task.Run(() => new CompanyModel
            {
                Id = companyDto.Id,
                Name = companyDto.Name,
                Description = companyDto.Description,
                Fax = companyDto.Fax,
                UpdatedAt = companyDto.UpdatedAt,
                AddressId = companyDto.AddressId,
                ContactId = companyDto.ContactId,
            });
        }
    }
}
