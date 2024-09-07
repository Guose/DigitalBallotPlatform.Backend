using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.County.DTOs
{
    public class CountyDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? State { get; set; }
        public BallotSystemType BallotTabulation { get; set; }
        public VoterSystemType VoterReg { get; set; }
        public int AddressId { get; set; }

        public CountyDTO() { }
        public CountyDTO(string name, string state, BallotSystemType ballotTab, VoterSystemType voterSystem, int addressId)
        {
            Name = name;
            State = state;
            BallotTabulation = ballotTab;
            VoterReg = voterSystem;
            AddressId = addressId;
        }

        public static async Task<CountyModel> MapCountyModel(CountyDTO countyDTO)
        {
            return await Task.Run(() => new CountyModel
            {
                Name = $"{countyDTO.Name}, {countyDTO.State}",
                BallotTabulation = countyDTO.BallotTabulation,
                VoterReg = countyDTO.VoterReg,
                AddressId = countyDTO.AddressId
            });
        }

        public static async Task<CountyDTO> MapCountyDto(CountyModel county)
        {
            string[] countyNameAndState = county.Name.Split(',');
            return await Task.Run(() => new CountyDTO
            {
                Id = county.Id,
                Name = countyNameAndState[0].Trim(),
                State = countyNameAndState[1].Trim(),
                BallotTabulation = county.BallotTabulation,
                VoterReg = county.VoterReg,
                AddressId = county.AddressId
            });
        }
    }
}
