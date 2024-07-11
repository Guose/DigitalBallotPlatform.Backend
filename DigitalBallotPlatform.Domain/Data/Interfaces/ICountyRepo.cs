using DigitalBallotPlatform.County.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface ICountyRepo : IGenericRepository<CountyModel>
    {
        Task<bool> ExecuteUpdateAsync(CountyDTO countyDto);
        Task<CountyDTO?> GetCountyByIdAsync(int id);
    }
}
