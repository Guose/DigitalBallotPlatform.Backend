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
        public CountyDTO(int id, BallotSystemType ballotTab, VoterSystemType voterSystem, int addressId)
        {
            Id = id;
            BallotTabulation = ballotTab;
            VoterReg = voterSystem;
            AddressId = addressId;
        }

        public static async Task<CountyModel> MapCountyModel(CountyDTO countyDTO)
        {
            return await Task.Run(() => new CountyModel
            {
                Id = countyDTO.Id,
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
