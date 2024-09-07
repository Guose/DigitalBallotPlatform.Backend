using DigitalBallotPlatform.County.DTOs;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Logger;

namespace DigitalBallotPlatform.Domain.Data.Repositories
{
    public class CountyRepo(ElectionDbContext context, ILogger logger) : 
        GenericRepository<CountyDTO, ElectionDbContext>(context, logger), ICountyRepo
    {
        public Task<bool> ExecuteUpdateAsync(CountyDTO countyDto)
        {
            throw new NotImplementedException();
        }

        public Task<CountyDTO?> GetCountyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
