using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Election.DTOs
{
    public class PartyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
        public int? ElectionId { get; set; }
        public int? WatermarkColorId { get; set; }

        public PartyDTO() { }
        public PartyDTO(int id, string name, string acronym, int electionId, int? watermarkColorId)
        {
            Id = id;
            Name = name;
            Acronym = acronym;
            ElectionId = electionId;
            WatermarkColorId = watermarkColorId;
        }

        public static async Task<PartyDTO> MapPartyDTO(PartyModel partyModel)
        {
            return await Task.Run(() => new PartyDTO
            {
                Id = partyModel.Id,
                Name = partyModel.Name,
                Acronym = partyModel.Acronym,
                ElectionId = partyModel.ElectionId,
                WatermarkColorId = partyModel.WatermarkColorId,
            });
        }

        public static async Task<PartyModel> MapPartyModel(PartyDTO partyDto)
        {
            return await Task.Run(() => new PartyModel
            {
                Id = partyDto.Id,
                Name = partyDto.Name,
                Acronym = partyDto.Acronym,
                ElectionId = partyDto.ElectionId,
                WatermarkColorId = partyDto.WatermarkColorId,
            });
        }
    }
}
