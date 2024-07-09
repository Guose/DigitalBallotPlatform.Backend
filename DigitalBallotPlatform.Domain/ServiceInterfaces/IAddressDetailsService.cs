using DigitalBallotPlatform.Company.DTOs;
using DigitalBallotPlatform.County.DTOs;
using DigitalBallotPlatform.Platform.DTOs;

namespace DigitalBallotPlatform.Domain.ServiceInterfaces
{
    public interface IAddressDetailsService
    {
        Task<AddressDetailsDTO> GetAddressDetailsForCountyAsync(CountyDTO countyDto);
        Task<AddressDetailsDTO> GetAddressDetailsForCompanyAsync(CompanyDTO companyDto);
    }
}
