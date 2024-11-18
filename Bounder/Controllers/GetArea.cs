using Bounder.Data;
using Microsoft.AspNetCore.Mvc;
using Bounder.Models;
using Bounder.Repositories.IRepositories;
using Bounder.Services;
using Microsoft.EntityFrameworkCore;
using Bounder.Models.NoDbModels;
using Bounder.CustomFilters;

namespace Bounder.Controllers
{
    [ApiController]
    [Route("api/geo")]
    public class GetArea : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyLocationRepository _companyLocationRepository;

        public GetArea(ILocationRepository repository, 
            ICompanyRepository companyRepository, 
            ICompanyLocationRepository companyLocationRepository)
        {
            _locationRepository = repository;
            _companyRepository = companyRepository;
            _companyLocationRepository = companyLocationRepository;
        }

        [HttpGet]
        [Route("get-companies")]
        [ApiKeyFilters]
        public async Task<IActionResult> getCompanies([FromQuery] string apiKey)
        {
            var companies = await _companyRepository.GetAll();
            if (companies == null)
                return BadRequest("Something went wrong");
            else if (companies.Count() == 0)
                return NotFound("Couldn't find any companies");
            return Ok(companies);
        }

        [HttpPost]
        [ApiKeyFilterSwagger]
        [Route("create area")]
        public IActionResult createCompany([FromBody] Company company, [FromHeader] string apiKey)
        {
            if(company != null)
            {
                _companyRepository.Create(company);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Coudn't create Company");
            }
        }

        [HttpPost]
        [Route("get company")]
        public async Task<IActionResult> GetCompaniesLocationIsIn([FromBody] Location location)
        {
            var companies = await _companyRepository.GetAll();
            var company = LocationInAreaService.getCompanyTheLocationIsWithin(location, companies.ToList());
            if (company == null)
                return BadRequest("Something went wrong");
            return Ok(company);
        }
    }
}