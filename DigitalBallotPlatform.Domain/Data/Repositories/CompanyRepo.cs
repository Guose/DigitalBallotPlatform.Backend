using DigitalBallotPlatform.Company.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;
using DigitalBallotPlatform.Shared.Models;
using LinqToDB.EntityFrameworkCore;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class CompanyRepo(PlatformDbContext context, ILogger logger) :
        GenericRepository<CompanyDTO, PlatformDbContext>(context, logger), ICompanyRepo
    {
        public async Task<bool> ExecuteUpdateAsync(CompanyDTO companyDto)
        {
            try
            {
                CompanyModel? company = await Context.Companies.FirstOrDefaultAsyncEF(c => c.Id == companyDto.Id);
                if (company == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(ExecuteUpdateAsync), this);
                    return false;
                }

                company = await CompanyDTO.MapCompanyModel(companyDto);

                Context.Companies.Update(company);
                await SaveAsync();

                Logger.LogInformation("[INFO] {0} Entity {1} has been updated", nameof(ExecuteUpdateAsync), nameof(CompanyModel));

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(ExecuteUpdateAsync));
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<CompanyDTO?> GetCompanyByIdAsync(int id)
        {
            try
            {
                CompanyModel? company = await Context.Companies.FirstOrDefaultAsyncEF(c => c.Id == id);
                if (company == null)
                {
                    Logger.LogWarning("[WARN] {0} {1} Entity could not be found in the database.", nameof(GetCompanyByIdAsync), this);
                    return null;
                }

                Logger.LogInformation("[INFO] {0} Message: Entity {1} query for ID: {2} was successfull", nameof(GetCompanyByIdAsync), nameof(CompanyModel), id);

                return await CompanyDTO.MapCompanyDto(company);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "[ERROR] {2} Message: {0} InnerException: {1}", ex.Message, ex.InnerException!, nameof(GetCompanyByIdAsync));
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
