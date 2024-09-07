using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IPartyRepo : IGenericRepository<PartyModel>
    {
        Task<bool> ExecuteUpdateAsync(PartyDTO partyDto);
        Task<PartyDTO?> GetPartyByIdAsync(int id);
    }
}
