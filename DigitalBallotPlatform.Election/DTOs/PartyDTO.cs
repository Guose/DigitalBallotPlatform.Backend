using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.Election.Models
{
    public class PartyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
        public string Abbreviations { get; set; } = string.Empty;
        public WatermarkType? WatermarkType { get; set; }
        public int? ColorId { get; set; }
        public int? ElectionId { get; set; }

        public PartyDTO() { }
        public PartyDTO(int id, string name, string acronym, string abbrev, WatermarkType watermarkType, int colorId, int electionId)
        {
            Id = id;
            Name = name;
            Acronym = acronym;
            Abbreviations = abbrev;
            WatermarkType = watermarkType;
            ColorId = colorId;
            ElectionId = electionId;
        }

        public static implicit operator PartyDTO(PartyModel partyModel)
        {
            return new PartyDTO
            {
               Id = partyModel.Id,
               Name = partyModel.Name,
               Acronym = partyModel.Acronym,
               Abbreviations = partyModel.Abbreviations,
               WatermarkType = partyModel.WatermarkType,
               ColorId = partyModel.ColorId,
               ElectionId = partyModel.ElectionId,
            };
        }

        public static implicit operator PartyModel(PartyDTO partyDto)
        {
            return new PartyModel
            {
                Id = partyDto.Id,
                Name = partyDto.Name,
                Acronym = partyDto.Acronym,
                Abbreviations = partyDto.Abbreviations,
                WatermarkType = partyDto.WatermarkType,
                ColorId = partyDto.ColorId,
                ElectionId = partyDto.ElectionId,
            };
        }
    }
}
