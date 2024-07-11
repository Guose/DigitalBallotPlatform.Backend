using DigitalBallotPlatform.Company.DTOs;
using DigitalBallotPlatform.County.DTOs;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalBallotPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountyController : ControllerBase
    {
        private readonly ICountyRepo countyRepo;
        private readonly ICompanyRepo companyRepo;

        public CountyController(ICountyRepo countyRepo, ICompanyRepo companyRepo)
        {
            this.countyRepo = countyRepo;
            this.companyRepo = companyRepo;
        }

        [HttpGet("County")]
        public async Task<ActionResult<IEnumerable<CountyDTO>>> GetCounties()
        {
            IEnumerable<CountyModel> countyDtos = await countyRepo.GetAllAsync();

            return countyDtos != null ?
                Ok(countyDtos) :
                NotFound(new { Message = $"{nameof(CountyDTO)} request could not be found." });
        }

        [HttpGet("County/{id}")]
        public async Task<ActionResult<CountyDTO>> GetCountyById(int id)
        {
            CountyDTO? countyDto = await countyRepo.GetCountyByIdAsync(id);

            return countyDto != null ?
                Ok(countyDto) :
                NotFound(new { Message = $"{nameof(CountyDTO)} request could not be found." });
        }

        [HttpPost("County")]
        public async Task<ActionResult> CreateCounty([FromBody] CountyDTO countyDto)
        {
            CountyModel county = await CountyDTO.MapCountyModel(countyDto);

            if (await countyRepo.ExecuteCreateAsync(county))
            {
                return Ok(county);
            }

            return BadRequest();
        }

        [HttpPut("County/{id}")]
        public async Task<ActionResult> UpdateCounty(int id, [FromBody] CountyDTO countyDto)
        {
            if (id != countyDto.Id)
            {
                return BadRequest();
            }

            if (await countyRepo.ExecuteUpdateAsync(countyDto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("County/{id}")]
        public async Task<ActionResult> DeleteCounty(int id)
        {
            CountyDTO? countyDto = await countyRepo.GetCountyByIdAsync(id);

            if (countyDto == null)
            {
                return NotFound(new { Message = $"{nameof(CountyDTO)} request could not be found." });
            }

            CountyModel county = await CountyDTO.MapCountyModel(countyDto);

            if (await countyRepo.ExecuteDeleteAsync(county))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpGet("Company")]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            IEnumerable<CompanyModel> companyDtos = await companyRepo.GetAllAsync();

            return companyDtos != null ?
                Ok(companyDtos) :
                NotFound(new { Message = $"{nameof(CompanyDTO)} request could not be found." });
        }

        [HttpGet("Company/{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompanyById(int id)
        {
            CompanyDTO? companyDto = await companyRepo.GetCompanyByIdAsync(id);

            return companyDto != null ?
                Ok(companyDto) :
                NotFound(new { Message = $"{nameof(CompanyDTO)} request could not be found." });
        }

        [HttpPost("Company")]
        public async Task<ActionResult> CreateCompany([FromBody] CompanyDTO companyDto)
        {
            CompanyModel company = await CompanyDTO.MapCompanyModel(companyDto);

            if (await companyRepo.ExecuteCreateAsync(company))
            {
                return Ok(company);
            }

            return BadRequest();
        }

        [HttpPut("Company/{id}")]
        public async Task<ActionResult> UpdateCompany(int id, [FromBody] CompanyDTO companyDto)
        {
            if (id != companyDto.Id)
            {
                return BadRequest();
            }

            if (await companyRepo.ExecuteUpdateAsync(companyDto))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("Company/{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            CompanyDTO? companyDto = await companyRepo.GetCompanyByIdAsync(id);

            if (companyDto == null)
            {
                return NotFound(new { Message = $"{nameof(CompanyDTO)} request could not be found." });
            }

            CompanyModel company = await CompanyDTO.MapCompanyModel(companyDto);

            if (await companyRepo.ExecuteDeleteAsync(company))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
