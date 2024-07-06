using DigitalBallotPlatform.Election.DTOs;

namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IPartyRepo : IGenericRepository<PartyDTO>
    {
        Task<bool> ExecuteUpdateAsync(PartyDTO partyDto);
        Task<PartyDTO?> GetPartyByIdAsync(int id);
    }
}
