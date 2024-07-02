using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.County.DTOs
{
    public class CountyDTO
    {
        public int Id { get; set; }
        public BallotSystemType BallotTabulation { get; set; }
        public VoterSystemType VoterReg { get; set; }

        public CountyDTO(int id, BallotSystemType ballotTab, VoterSystemType voterSystem)
        {
            Id = id;
            BallotTabulation = ballotTab;
            VoterReg = voterSystem;
        }
    }
}
