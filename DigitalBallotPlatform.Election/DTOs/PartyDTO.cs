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
        public int ColorId { get; set; }
        public int ElectionId { get; set; }

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
    }
}
