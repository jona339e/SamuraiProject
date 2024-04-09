using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samurai.Repo.Interfaces;

namespace Samurai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiRepository _samuraRepository;
        public SamuraiController(ISamuraiRepository samuraiRepository)
        {
            _samuraRepository = samuraiRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {

        }
    }
}
