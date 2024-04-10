using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Models;

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

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var result = _samuraRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Samurais samurai)
        {
            var result = _samuraRepository.Create(samurai);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Samurais samurai)
        {
            var result = _samuraRepository.Update(samurai);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(Samurais samurai)
        {
            var result = _samuraRepository.Delete(samurai);
            return Ok();
        }
    }
}
