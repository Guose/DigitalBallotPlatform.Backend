using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Election.DTOs;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBallotPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionSetupController : ControllerBase
    {
        private readonly IElectionSetupRepo electionSetupRepo;
        private readonly IPartyRepo partyRepo;

        public ElectionSetupController(IElectionSetupRepo electionSetupRepo, IPartyRepo partyRepo)
        {
            this.electionSetupRepo = electionSetupRepo;
            this.partyRepo = partyRepo;
        }

        [HttpGet("ElectionSetup")]
        public async Task<ActionResult<IEnumerable<ElectionSetupDTO>>> GetElectionSetups()
        {
            IEnumerable<ElectionSetupModel> electionSetupDTOs = await electionSetupRepo.GetAllAsync();

            return electionSetupDTOs != null ?
                Ok(electionSetupDTOs) :
                NotFound(new { Message = $"{nameof(ElectionSetupDTO)} request could not be found." });
        }

        [HttpGet("ElectionSetup/{id}")]
        public async Task<ActionResult<ElectionSetupDTO>> GetElectionSetupById(int id)
        {
            ElectionSetupDTO? electionSetupDto = await electionSetupRepo.GetElectionByIdAsync(id);

            return electionSetupDto != null ?
                Ok(electionSetupDto) :
                NotFound(new { Message = $"{nameof(ElectionSetupDTO)} request could not be found." });
        }

        [HttpPost("ElectionSetup")]
        public async Task<ActionResult> CreateElectionSetup([FromBody] ElectionSetupDTO electionSetupDTO)
        {
            ElectionSetupModel electionSetup = await ElectionSetupDTO.MapElectionSetupModel(electionSetupDTO);

            if (await electionSetupRepo.ExecuteCreateAsync(electionSetup))
            {
                return Ok(electionSetupDTO);
            }

            return BadRequest();
        }

        [HttpPut("ElectionSetup/{id}")]
        public async Task<ActionResult> UpdateElectionSetup(int id, [FromBody] ElectionSetupDTO electionSetupDTO)
        {
            if (id != electionSetupDTO.Id)
            {
                return BadRequest();
            }

            if (await electionSetupRepo.ExecuteUpdateAsync(electionSetupDTO))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("ElectionSetup/{id}")]
        public async Task<ActionResult> DeleteElectionSetup(int id)
        {
            ElectionSetupDTO? electionSetupDto = await electionSetupRepo.GetElectionByIdAsync(id);

            if (electionSetupDto == null)
            {
                return NotFound(new { Message = $"{nameof(ElectionSetupDTO)} request could not be found." });
            }

            ElectionSetupModel electionSetup = await ElectionSetupDTO.MapElectionSetupModel(electionSetupDto);

            if (await electionSetupRepo.ExecuteDeleteAsync(electionSetup))
            {
                return NoContent();
            }

            return BadRequest();
        }


        [HttpGet("Party")]
        public async Task<ActionResult<IEnumerable<PartyDTO>>> GetParties()
        {
            IEnumerable<PartyModel> parties = await partyRepo.GetAllAsync();

            return parties != null ?
                Ok(parties) :
                NotFound(new { Message = $"{nameof(PartyDTO)} request could not be found." });
        }

        [HttpPost("Party")]
        public async Task<ActionResult> CreateParty([FromBody] PartyDTO partyDto)
        {
            PartyModel party = await PartyDTO.MapPartyModel(partyDto);

            if (await partyRepo.ExecuteCreateAsync(party))
            {
                return Ok(partyDto);
            }

            return BadRequest();
        }
    }
}
