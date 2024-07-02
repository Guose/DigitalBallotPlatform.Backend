using DigitalBallotPlatform.Shared.Types;

namespace DigitalBallotPlatform.Election.Models
{
    public class PartyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string Abbreviations { get; set; }
        public bool IsHeaderFile { get; set; }
        public WatermarkType? WatermarkType { get; set; }
        public int ColorId { get; set; }
        public int ElectionId { get; set; }

        public PartyDTO(int id, string name, string acronym, string abbrev, bool isHeaderFile, WatermarkType watermarkType, int colorId, int electionId)
        {
            Id = id;
            Name = name;
            Acronym = acronym;
            Abbreviations = abbrev;
            IsHeaderFile = isHeaderFile;
            WatermarkType = watermarkType;
            ColorId = colorId;
            ElectionId = electionId;
        }
    }
}
