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
        public IActionResult GetAnimals([FromQuery] Species? species = null, [FromQuery] Size? size = null, [FromQuery] Age? age = null, [FromQuery] Genre? genre = null) {
        
            var animals = _animalRepository.GetAll(species, size,age, genre);
            return Ok(animals);
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetAnimalById(int Id)
        {
            var animal = _animalRepository.GetByID(Id);
            return Ok(animal);
        }
    }
}
