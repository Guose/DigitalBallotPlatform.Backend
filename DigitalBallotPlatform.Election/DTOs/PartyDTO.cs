using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Election.Models
{
    public class PartyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
        public int? ElectionId { get; set; }

        public PartyDTO() { }
        public PartyDTO(int id, string name, string acronym, int electionId)
        {
            Id = id;
            Name = name;
            Acronym = acronym;
            ElectionId = electionId;
        }

        public static implicit operator PartyDTO(PartyModel partyModel)
        {
            return new PartyDTO
            {
               Id = partyModel.Id,
               Name = partyModel.Name,
               Acronym = partyModel.Acronym,
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
                ElectionId = partyDto.ElectionId,
            };
        }

        public static async Task<PartyDTO> MapPartyDTO(PartyModel partyModel)
        {
            return await Task.Run(() => new PartyDTO
            {
                Id = partyModel.Id,
                Name = partyModel.Name,
                Acronym = partyModel.Acronym,
                ElectionId = partyModel.ElectionId,
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
            });
        }
    }
}
