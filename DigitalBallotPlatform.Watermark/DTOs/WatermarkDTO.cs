using DigitalBallotPlatform.Shared.Models;

namespace DigitalBallotPlatform.Watermark.DTOs
{
    public class WatermarkDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public WatermarkDTO() { }
        public WatermarkDTO(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static async Task<WatermarkModel> MapWatermarkModel(WatermarkDTO watermarkDTO)
        {
            return await Task.Run(() => new WatermarkModel
            {
                Id = watermarkDTO.Id,
                Name = watermarkDTO.Name,
                Description = watermarkDTO.Description,
            });
        }

        public static async Task<WatermarkDTO> MapWatermarkDto(WatermarkModel watermark)
        {
            return await Task.Run(() => new WatermarkDTO
            {
                Id = watermark.Id,
                Name = watermark.Name,
                Description = watermark.Description,
            });
        }
    }
}
