using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Election.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IPartyRepo : IGenericRepository<PartyDTO>
    {
        Task<bool> ExecuteUpdateAsync(PartyDTO partyDto);
        Task<PartyDTO?> GetElectionByIdAsync(int id);
    }
}
