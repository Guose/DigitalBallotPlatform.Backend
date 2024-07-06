using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.Election.DTOs;

namespace DigitalBallotPlatform.Domain.CompositeDTOs
{
    public class ElectionWithBallotComposite
    {
        public ElectionSetupDTO Election { get; set; } = new();
        public BallotSpecDTO BallotSpec { get; set; } = new();

        public ElectionWithBallotComposite() { }
        public ElectionWithBallotComposite(ElectionSetupDTO election, BallotSpecDTO ballotSpec)
        {
            Election = election;
            BallotSpec = ballotSpec;
        }
    }
}
