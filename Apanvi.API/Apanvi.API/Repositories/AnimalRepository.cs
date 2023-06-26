using Apanvi.API.Models;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace Apanvi.API.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private ConcurrentBag<Animal> _animalsDb = new ConcurrentBag<Animal>();        // é uma variavel mas concurrentBag e o "_" se usa qnd for usar algo da interface
                public AnimalRepository()
        {
            _animalsDb.Add(new Animal
            {
                Name = "name",
                Description = "description",
                Size = Size.Small,
                Species = Species.Cat,
                Genre = Genre.Male,
                
            });

            _animalsDb.Add(new Animal
            {
                Name = "name",
                Description = "description",
                Size = Size.Large,
                Species = Species.Dog,
                Genre = Genre.Female,

            });
        }

        public List<Animal> GetAll(Species? species, Size? size, Genre? genre)
        {
            var animals = _animalsDb.ToList();
            if (species != null)
            {
                animals = animals.Where(animal => animal.Species == species).ToList();
            }
            if (size != null)
            {
                animals = animals.Where(animal => animal.Size == size).ToList();
            }
            if (size != null)
            {
                animals = animals.Where(animal => animal.Genre == genre).ToList();
            }

            return animals;
        }
    }
    

    }

