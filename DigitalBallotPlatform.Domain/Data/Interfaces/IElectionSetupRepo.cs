using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IElectionSetupRepo : IGenericRepository<ElectionSetupModel>
    {
        Task<bool> ExecuteUpdateAsync(ElectionSetupDTO electionSetupDTO);
        Task<ElectionSetupDTO?> GetElectionByIdAsync(int id);
    }
}
