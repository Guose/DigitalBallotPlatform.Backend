using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Models;
using DigitalBallotPlatform.Watermark.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBallotPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatermarkController : ControllerBase
    {
        private readonly IWatermarkRepo watermarkRepo;
        private readonly IWatermarkColorsRepo watermarkColorsRepo;

        public WatermarkController(IWatermarkRepo watermarkRepo, IWatermarkColorsRepo watermarkColorsRepo)
        {
            this.watermarkRepo = watermarkRepo;
            this.watermarkColorsRepo = watermarkColorsRepo;
        }

        [HttpGet("Watermark")]
        public async Task<ActionResult<IEnumerable<WatermarkDTO>>> GetWatermarks()
        {
            IEnumerable<WatermarkModel> watermarks = await watermarkRepo.GetAllAsync();

            return watermarks != null ?
                Ok(watermarks) :
                NotFound(new { Message = $"{nameof(WatermarkColorDTO)} request could not be found." });
        }

        [HttpGet("Watermark/{id}")]
        public async Task<ActionResult<WatermarkDTO>> GetWatermarkById(int id)
        {
            WatermarkDTO? watermarkDto = await watermarkRepo.GetWatermarkById(id);

            return watermarkDto != null ?
                Ok(watermarkDto) :
                NotFound(new { Message = $"{nameof(WatermarkColorDTO)} request could not be found." });
        }

        [HttpPost("Watermark")]
        public async Task<ActionResult> CreateWatermark([FromBody] WatermarkDTO watermarkDTO)
        {
            WatermarkModel? watermark = await WatermarkDTO.MapWatermarkModel(watermarkDTO);

            if (await watermarkRepo.ExecuteCreateAsync(watermark))
            {
                NoContent();
            }

            return BadRequest();
        }

        [HttpGet("WatermarkColor")]
        public async Task<ActionResult<IEnumerable<WatermarkColorDTO>>> GetWatermarkColors()
        {
            IEnumerable<WatermarkColorModel> watermarkColors = await watermarkColorsRepo.GetAllAsync();

            return watermarkColors != null ?
                Ok(watermarkColors) :
                NotFound(new { Message = $"{nameof(WatermarkColorDTO)} request could not be found." });
        }

        [HttpGet("WatermarkColor/{id}")]
        public async Task<ActionResult<WatermarkColorDTO>> GetWatermarkColorById(int id)
        {
            WatermarkColorDTO? watermarkColorDto = await watermarkColorsRepo.GetWatermarkColorById(id);

            return watermarkColorDto != null ?
                Ok(watermarkColorDto) :
                NotFound(new { Message = $"{nameof(WatermarkColorDTO)} request could not be found." });
        }

        [HttpPost("WatermarkColor")]
        public async Task<ActionResult> CreateWatermarkColor([FromBody] WatermarkColorDTO watermarkDTO)
        {
            WatermarkColorModel? watermarkColor = await WatermarkColorDTO.MapWatermarkColorModel(watermarkDTO);

            if (await watermarkColorsRepo.ExecuteCreateAsync(watermarkColor))
            {
                NoContent();
            }

            return BadRequest();
        }
    }
}
