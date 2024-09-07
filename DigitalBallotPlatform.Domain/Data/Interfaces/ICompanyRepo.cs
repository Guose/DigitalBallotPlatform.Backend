using DigitalBallotPlatform.Company.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface ICompanyRepo : IGenericRepository<CompanyModel>
    {
        Task<bool> ExecuteUpdateAsync(CompanyDTO companyDto);
        Task<CompanyDTO?> GetCompanyByIdAsync(int id);
    }
}
