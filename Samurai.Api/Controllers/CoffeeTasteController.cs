using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Models;

namespace Samurai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeTasteController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        public CoffeeTasteController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        [HttpPost]
        public Task<ActionResult<Coffee>> Post()
        {

        }

    }
}
