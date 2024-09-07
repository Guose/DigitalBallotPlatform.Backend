using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Watermark.DTOs
{
    public class WatermarkColorDTO
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Tint { get; set; } = string.Empty;
        public bool HasHeaderFill { get; set; } = false;
        public List<PartyModel>? Parties { get; set; }

        public WatermarkColorDTO() { }
        public WatermarkColorDTO(string color, string tint, bool hasHeaderFill)
        {
            Color = color;
            Tint = tint;
            HasHeaderFill = hasHeaderFill;
            Parties = new List<PartyModel>();
        }

        public static async Task<WatermarkColorModel> MapWatermarkColorModel(WatermarkColorDTO watermarkColorDTO)
        {
            return await Task.Run(() => new WatermarkColorModel
            {
                Color = watermarkColorDTO.Color,
                Tint = watermarkColorDTO.Tint,
                HasHeaderFill = watermarkColorDTO.HasHeaderFill,
            });
        }

        public static async Task<WatermarkColorDTO> MapWatermarkColorDto(WatermarkColorModel watermark)
        {
            return await Task.Run(() => new WatermarkColorDTO
            {
                Id = watermark.Id,
                Color = watermark.Color,
                Tint = watermark.Tint,
                HasHeaderFill = watermark.HasHeaderFill,
            });
        }
    }
}
