using DigitalBallotPlatform.Election.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IElectionSetupRepo : IGenericRepository<ElectionSetupDTO>
    {
        Task<bool> ExecuteUpdateAsync(ElectionSetupDTO electionSetupDTO);
        Task<ElectionSetupDTO?> GetElectionByIdAsync(int id);
    }
}
