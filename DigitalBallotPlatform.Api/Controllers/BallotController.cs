using DigitalBallotPlatform.Ballot.DTOs;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using ILogger = DigitalBallotPlatform.Shared.Logger.ILogger;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBallotPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BallotController : ControllerBase
    {
        private readonly IBallotCategoryRepo ballotCategoryRepo;
        private readonly IBallotMaterialRepo ballotMaterialRepo;
        private readonly IBallotSpecRepo ballotSpecRepo;
        
        public ILogger Logger { get; }

        public BallotController(
            ILogger logger, 
            IBallotCategoryRepo ballotCategoryRepo, 
            IBallotMaterialRepo ballotMaterialRepo, 
            IBallotSpecRepo ballotSpecRepo)
        {
            Logger = logger;
            this.ballotCategoryRepo = ballotCategoryRepo;
            this.ballotMaterialRepo = ballotMaterialRepo;
            this.ballotSpecRepo = ballotSpecRepo;
        }

        [HttpGet("BallotCategory")]
        public async Task<ActionResult<IEnumerable<BallotCategoryDTO>>> GetBallotCategories()
        {
            IEnumerable<BallotCategoryModel> ballotCategories = await ballotCategoryRepo.GetAllAsync();

            return ballotCategories != null ?
                Ok(ballotCategories) :
                NotFound(new { Message = $"{nameof(BallotCategoryDTO)} request could not be found." });
        }

        [HttpGet("BallotCategory/{id}")]
        public async Task<ActionResult<BallotCategoryDTO>> GetBallotCategoryById(int id)
        {
            BallotCategoryDTO? ballotCategory = await ballotCategoryRepo.GetBallotCategoryByIdAsync(id);

            return ballotCategory != null ?
                Ok(ballotCategory) :
                NotFound(new { Message = $"{nameof(BallotCategoryDTO)} request could not be found." });
        }

        [HttpPost("BallotCategory")]
        public async Task<ActionResult> CreateBallotCategory([FromBody] BallotCategoryDTO ballotCategoryDto)
        {
            BallotCategoryModel ballotCategory = await BallotCategoryDTO.MapBallotCategoryModel(ballotCategoryDto);

            if (await ballotCategoryRepo.ExecuteCreateAsync(ballotCategory))
            {
                return Ok(ballotCategory);
            }

            return BadRequest();
        }

        [HttpPut("BallotCategory/{id}")]
        public async Task<ActionResult> UpdateBallotCategory(int id, [FromBody] BallotCategoryDTO ballotCategoryDto)
        {
            if (id != ballotCategoryDto.Id)
            {
                return BadRequest();
            }

            if (await ballotCategoryRepo.ExecuteUpdateAsync(ballotCategoryDto))
            {
                return Ok(ballotCategoryDto);
            }

            return BadRequest();
        }

        [HttpDelete("BallotCategory/{id}")]
        public async Task<ActionResult> DeleteBallotCategory(int id)
        {
            BallotCategoryDTO? ballotCategoryDto = await ballotCategoryRepo.GetBallotCategoryByIdAsync(id);

            if (ballotCategoryDto == null)
            {
                return NotFound();
            }

            BallotCategoryModel ballotMapped = await BallotCategoryDTO.MapBallotCategoryModel(ballotCategoryDto);

            if (await ballotCategoryRepo.ExecuteDeleteAsync(ballotMapped))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpGet("BallotMaterial")]
        public async Task<ActionResult<IEnumerable<BallotMaterialDTO>>> GetBallotMaterials()
        {
            IEnumerable<BallotMaterialModel> ballotMaterials = await ballotMaterialRepo.GetAllAsync();

            return ballotMaterials != null ?
                Ok(ballotMaterials) :
                NotFound(new { Message = $"{nameof(BallotMaterialDTO)} request could not be found." });
        }

        [HttpGet("BallotMaterial/{id}")]
        public async Task<ActionResult<BallotMaterialDTO>> GetBallotMaterialById(int id)
        {
            BallotMaterialDTO? ballotMaterial = await ballotMaterialRepo.GetBallotMaterialByIdAsync(id);

            return ballotMaterial != null ?
                Ok(ballotMaterial) :
                NotFound(new { Message = $"{nameof(BallotMaterialDTO)} request could not be found." });
        }

        [HttpPost("BallotMaterial")]
        public async Task<ActionResult> CreateBallotMaterial([FromBody] BallotMaterialDTO ballotMaterialDto)
        {
            BallotMaterialModel? ballotMaterial = await BallotMaterialDTO.MapBallotMaterialModel(ballotMaterialDto);

            if (await ballotMaterialRepo.ExecuteCreateAsync(ballotMaterial))
            {
                return Ok(ballotMaterial);
            }

            return BadRequest();
        }

        [HttpPut("BallotMaterial/{id}")]
        public async Task<ActionResult> UpdateBallotMaterial(int id, [FromBody] BallotMaterialDTO ballotMaterialDto)
        {
            if (id != ballotMaterialDto.Id)
            {
                return BadRequest();
            }

            if (await ballotMaterialRepo.ExecuteUpdateAsync(ballotMaterialDto))
            {
                return Ok(ballotMaterialDto);
            }

            return BadRequest();
        }

        [HttpDelete("BallotMaterial/{id}")]
        public async Task<ActionResult> DeleteBallotMaterial(int id)
        {
            BallotMaterialDTO? ballotMaterialDto = await ballotMaterialRepo.GetBallotMaterialByIdAsync(id);

            if (ballotMaterialDto == null)
            {
                return NotFound(new { Message = $"{nameof(BallotMaterialDTO)} Id: {id} request could not be found." });
            }

            BallotMaterialModel ballotMapped = await BallotMaterialDTO.MapBallotMaterialModel(ballotMaterialDto);

            if (await ballotMaterialRepo.ExecuteDeleteAsync(ballotMapped))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpGet("BallotSpec")]
        public async Task<ActionResult<IEnumerable<BallotSpecDTO>>> GetBallotSpecs()
        {
            IEnumerable<BallotMaterialModel> ballotMaterials = await ballotMaterialRepo.GetAllAsync();

            return ballotMaterials != null ?
                Ok(ballotMaterials) :
                NotFound(new { Message = $"{nameof(BallotSpecDTO)} request could not be found." });
        }

        [HttpGet("BallotSpec/{id}")]
        public async Task<ActionResult<BallotSpecDTO>> GetBallotSpecById(int id)
        {
            BallotSpecDTO? ballotSpecDto = await ballotSpecRepo.GetBallotSpecByIdAsync(id);

            return ballotSpecDto != null ?
                Ok(ballotSpecDto) :
                NotFound(new { Message = $"{nameof(BallotSpecDTO)} request could not be found." });
        }

        [HttpPost("BallotSpec")]
        public async Task<ActionResult> CreateBallotSpec([FromBody] BallotSpecDTO ballotSpecDto)
        {
            BallotSpecModel? ballotSpec = await BallotSpecDTO.MapBallotSpecModel(ballotSpecDto);

            if (await ballotSpecRepo.ExecuteCreateAsync(ballotSpec))
            {
                return Ok(ballotSpec);
            }

            return BadRequest();
        }

        [HttpPut("BallotSpec/{id}")]
        public async Task<ActionResult> UpdateBallotSpec(int id, [FromBody] BallotSpecDTO ballotSpecDto)
        {
            if (id != ballotSpecDto.Id)
            {
                return BadRequest();
            }

            if (await ballotSpecRepo.ExecuteUpdateAsync(ballotSpecDto))
            {
                return Ok(ballotSpecDto);
            }

            return BadRequest();
        }

        [HttpDelete("BallotSpec/{id}")]
        public async Task<ActionResult> DeleteBallotSpec(int id)
        {
            BallotSpecDTO? ballotSpecDto = await ballotSpecRepo.GetBallotSpecByIdAsync(id);

            if (ballotSpecDto == null)
            {
                return NotFound(new { Message = $"{nameof(BallotSpecDTO)} Id: {id} request could not be found." });
            }

            BallotSpecModel ballotMapped = await BallotSpecDTO.MapBallotSpecModel(ballotSpecDto);

            if (await ballotSpecRepo.ExecuteDeleteAsync(ballotMapped))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
