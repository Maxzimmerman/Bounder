using Bounder.Data;
using Microsoft.AspNetCore.Mvc;
using Bounder.Models;
using Bounder.Repositories.IRepositories;
using Bounder.Services;
using Microsoft.EntityFrameworkCore;

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
        [Route("just get company from db")]
        public async Task<IActionResult> get()
        {
            var companies = await _companyRepository.GetAll();
            return Ok(companies);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> getAll()
        {
            var companies = await _companyRepository.GetAll();
            var service = new LocationInAreaService();
            var locationNotWithin = new Location() { Id = 0, Title = "Pik dahme", Latitude = 50.10900970200649, Longitude = 8.66738858553383 };
            var locationWithin = new Location() { Id = 0, Title = "Pik dahme", Latitude = 50.10894779572615, Longitude=8.667290458508749 };
            var company = service.getCompanyTheLocationIsWithin(locationNotWithin, companies.ToList());
            return Ok(company);
        }
    }
}