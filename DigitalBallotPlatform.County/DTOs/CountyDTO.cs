using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.County.DTOs
{
    public class CountyDTO
    {
        public int Id { get; set; }
        public BallotSystemType BallotTabulation { get; set; }
        public VoterSystemType VoterReg { get; set; }
        public int AddressId { get; set; }

        public CountyDTO() { }
        public CountyDTO(BallotSystemType ballotTab, VoterSystemType voterSystem, int addressId)
        {
            BallotTabulation = ballotTab;
            VoterReg = voterSystem;
            AddressId = addressId;
        }

        public static async Task<CountyModel> MapCountyModel(CountyDTO countyDTO)
        {
            return await Task.Run(() => new CountyModel
            {
                BallotTabulation = countyDTO.BallotTabulation,
                VoterReg = countyDTO.VoterReg,
                AddressId = countyDTO.AddressId
            });
        }

        public static async Task<CountyDTO> MapCountyDto(CountyModel county)
        {
            return await Task.Run(() => new CountyDTO
            {
                Id = county.Id,
                BallotTabulation = county.BallotTabulation,
                VoterReg = county.VoterReg,
                AddressId = county.AddressId
            });
        }
    }
}
