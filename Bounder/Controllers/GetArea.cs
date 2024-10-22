using Bounder.Data;
using Microsoft.AspNetCore.Mvc;
using Bounder.Models;

namespace Bounder.Controllers
{
    [ApiController]
    [Route("api/geo")]
    public class GetArea : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetArea(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get()
        {
            return Ok(_context.Locations.ToList());
        }
    }
}
