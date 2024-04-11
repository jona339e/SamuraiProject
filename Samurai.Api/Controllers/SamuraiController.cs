using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samurai.Repo.DTOs;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Models;
using Samurai.Repo.Services;

namespace Samurai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiRepository _samuraRepository;
        private readonly IMappingService _mappingService;
        public SamuraiController(ISamuraiRepository samuraiRepository, IMappingService mappingService)
        {
            _samuraRepository = samuraiRepository;
            _mappingService = mappingService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _samuraRepository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _samuraRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(SamuraiDto samurai)
        {
            var result = _samuraRepository.Create(_mappingService.SamuraiDtoToSamurais(samurai));
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(SamuraiDto samurai)
        {
            var result = _samuraRepository.Update(_mappingService.SamuraiDtoToSamurais(samurai));
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(SamuraiDto samurai)
        {
            var result = _samuraRepository.Delete(_mappingService.SamuraiDtoToSamurais(samurai));
            return Ok(result);
        }
    }
}
