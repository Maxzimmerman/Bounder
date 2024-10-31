using Bounder.Data;
using Microsoft.AspNetCore.Mvc;
using Bounder.Models;
using Bounder.Repositories.IRepositories;
using Bounder.Services;
using Microsoft.EntityFrameworkCore;
using Bounder.Models.NoDbModels;

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

        [HttpPost]
        [Route("get message")]
        public async Task<IActionResult> getAll([FromBody] Location location)
        {
            var companies = await _companyRepository.GetAll();
            var service = new LocationInAreaService();
            var company = service.getCompanyTheLocationIsWithin(location, companies.ToList());
            var message = new Message(company, "max");
            return Ok(message);
        }
    }
}