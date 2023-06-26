using Apanvi.API.Models;
using Apanvi.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Apanvi.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository) { 
            _animalRepository = animalRepository;
        }
        [HttpGet]
        public IActionResult GetAnimals([FromQuery] Species? species = null, [FromQuery] Size? size = null, [FromQuery] Genre? genre = null) {
        
            var animals = _animalRepository.GetAll(species, size, genre);
            return Ok(animals);
        }
    }
}
