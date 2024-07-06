using DigitalBallotPlatform.County.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface ICountyRepo : IGenericRepository<CountyDTO>
    {
        Task<bool> ExecuteUpdateAsync(CountyDTO countyDto);
        Task<CountyDTO?> GetCountyByIdAsync(int id);
    }
}
