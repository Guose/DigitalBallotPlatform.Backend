using DigitalBallotPlatform.Company.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface ICompanyRepo : IGenericRepository<CompanyDTO>
    {
        Task<bool> ExecuteUpdateAsync(CompanyDTO companyDto);
        Task<CompanyDTO?> GetCompanyByIdAsync(int id);
    }
}
