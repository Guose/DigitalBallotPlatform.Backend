using DigitalBallotPlatform.Company.DTOs;
using DigitalBallotPlatform.County.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.ServiceInterfaces;
using DigitalBallotPlatform.Platform.DTOs;

namespace DigitalBallotPlatform.Domain.ServiceHelpers
{
    public class AddressServices : IAddressDetailsService
    {
        private readonly ElectionDbContext electionDbContext;

        public AddressServices(ElectionDbContext electionDbContext)
        {
            this.electionDbContext = electionDbContext;
        }

        public async Task<AddressDetailsDTO> GetAddressDetailsForCountyAsync(CountyDTO countyDto)
        {
            var address = await electionDbContext.Addresses.FindAsync(countyDto.AddressId);
            var county = await electionDbContext.Counties.FindAsync(address!.County!.Id);

            return new AddressDetailsDTO
            {
                CountyName = county!.Name,
                StreetAddress1 = address.Address1,
                StreetAddress2 = address.Address2,
                City = address.City,
                State = address.State,
                ZipCode = address.Zipcode,
            };
        }

        public async Task<AddressDetailsDTO> GetAddressDetailsForCompanyAsync(CompanyDTO companyDto)
        {
            var address = await electionDbContext.Addresses.FindAsync(companyDto.AddressId);
            var company = await electionDbContext.Companies.FindAsync(address!.Company!.Id);

            return new AddressDetailsDTO
            {
                CompanyName = company!.Name,
                StreetAddress1 = address.Address1,
                StreetAddress2 = address.Address2,
                City = address.City,
                State = address.State,
                ZipCode = address.Zipcode,
            };
        }
    }
}
