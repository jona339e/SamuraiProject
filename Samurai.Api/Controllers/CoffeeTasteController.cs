using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Samurai.Repo.DTOs;
using Samurai.Repo.Interfaces;
using Samurai.Repo.Models;

namespace Samurai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeTasteController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly ITasteRepository _tasteRepository;
        public CoffeeTasteController(ICoffeeRepository coffeeRepository, ITasteRepository tasteRepository)
        {
            _coffeeRepository = coffeeRepository;
            _tasteRepository = tasteRepository;
        }

        [HttpPost("Coffee")]
        public async Task<ActionResult<Coffee>> Post(CoffeeDTO model)
        {
            // map dto to model

            var coffee = new Coffee
            {
                Name = model.Name
            };

            return Ok(await _coffeeRepository.Create(coffee));
        }

        [HttpPost("Taste")]
        public async Task<ActionResult<Taste>> Post(TasteDTO model)
        {
            // map dto to model

            var taste = new Taste
            {
                Name = model.Name,
                Description = model.Description
            };

            return Ok(await _tasteRepository.Create(taste));
        }

        [HttpGet("Taste")]
        public async Task<ActionResult<Taste>> GetTaste()
        {
            return Ok(await _tasteRepository.GetAll());
        }

        [HttpGet("Coffee")]
        public async Task<ActionResult<List<CoffeeDTOWithTastes>>> GetAll()
        {

            var coffees = await _coffeeRepository.GetAll();

            var coffeeDTOs = new List<CoffeeDTOWithTastes>();

            foreach (var coffee in coffees)
            {
                var coffeeDTO = new CoffeeDTOWithTastes
                {
                    Id = coffee.Id,
                    Name = coffee.Name,
                    Tastes = coffee.CoffeeTastes.Select(x => new TasteDTO
                    {
                        Id = x.Taste.Id,
                        Name = x.Taste.Name,
                        Description = x.Taste.Description
                    }).ToList()
                };

                coffeeDTOs.Add(coffeeDTO);
            }

            return Ok(coffeeDTOs);

        }

        [HttpPut("Coffee")]
        public async Task<ActionResult<CoffeeDTOWithTastes>> Put(CoffeeDTOWithTastes coffee)
        {
            Coffee coffeeModel = new();
            coffeeModel = await _coffeeRepository.GetByName(coffee.Name);

            if (coffeeModel == null)
                return NotFound();

            // find the tastes in the database
            foreach (var taste in coffee.Tastes)
            {
                var tasteModel = await _tasteRepository.GetByName(taste.Name);

                if (tasteModel == null)
                {
                    // create the taste if it does not exist
                    tasteModel = new Taste
                    {
                        Name = taste.Name,
                        Description = taste.Description
                    };
                    // add it to the database
                    tasteModel = await _tasteRepository.Create(tasteModel);

                }
                
                coffeeModel.CoffeeTastes = new List<CoffeeTaste>();

                CoffeeTaste coffeeTaste = new CoffeeTaste
                {
                    CoffeeId = coffeeModel.Id,
                    TasteId = tasteModel.Id
                };

                coffeeModel.CoffeeTastes.Add(coffeeTaste);

            }

            var updatedCoffee = await _coffeeRepository.Update(coffeeModel);

            var coffeeDTO = new CoffeeDTOWithTastes
            {
                Id = updatedCoffee.Id,
                Name = updatedCoffee.Name,
                Tastes = updatedCoffee.CoffeeTastes.Select(x => new TasteDTO
                {
                    Id = x.Taste.Id,
                    Name = x.Taste.Name,
                    Description = x.Taste.Description
                }).ToList()
            };

            return Ok(coffeeDTO);

           

        }


    }
}
