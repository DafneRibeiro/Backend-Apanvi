using Apanvi.API.Models;
using System.Collections.Concurrent;


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
            _animalsDb.Add(new Animal
            {
                Name = "name",
                Description = "description",
                Size = Size.Medium,
                Species = Species.Dog,
                Genre = Genre.Female,

            });
        }

        public List<Animal> GetAll(Species? species = null, Size? size = null, Genre? genre = null)
        {
            var animals = _animalsDb.ToList();
            if (species.HasValue)
            {
                animals = animals.Where(animal => animal.Species == species).ToList();
            }
            if (size.HasValue)
            {
                animals = animals.Where(animal => animal.Size == size).ToList();
            }
            if (genre.HasValue)
            {
                animals = animals.Where(animal => animal.Genre == genre).ToList();
            }

            return animals;
        }
       
    }
    

    }

