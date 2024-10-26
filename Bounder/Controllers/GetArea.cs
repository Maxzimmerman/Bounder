using Bounder.Data;
using Microsoft.AspNetCore.Mvc;
using Bounder.Models;
using Bounder.Repositories.IRepositories;
using Bounder.Services;

namespace Bounder.Controllers
{
    [ApiController]
    [Route("api/geo")]
    public class GetArea : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public GetArea(ILocationRepository repository)
        {
            _locationRepository = repository;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> getAll()
        {
            var service = new LocationInAreaService();
            bool isInArea = service.IsPointWithinArea(new Location() { Id=0, Title="Pik dahme", Latitude=50.10900970200649, Longitude=8.66738858553383 });
            return Ok(isInArea);
        }
    }
}