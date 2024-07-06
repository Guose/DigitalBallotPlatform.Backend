using DigitalBallotPlatform.Domain.CompositeDTOs;

namespace DigitalBallotPlatform.Domain.ServiceInterfaces
{
    public interface IElectionService
    {
        Task<ElectionWithBallotComposite> GetElectionWithBallotSpecAsync(int electionId);
    }
}
