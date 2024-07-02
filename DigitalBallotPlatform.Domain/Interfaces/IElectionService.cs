using DigitalBallotPlatform.Domain.CompositeDTOs;

namespace DigitalBallotPlatform.Domain.Interfaces
{
    public interface IElectionService
    {
        Task<ElectionWithBallotComposite> GetElectionWithBallotSpecAsync(int electionId);
    }
}
