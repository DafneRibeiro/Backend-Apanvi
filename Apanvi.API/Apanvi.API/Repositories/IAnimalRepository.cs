using Apanvi.API.Models;

namespace Apanvi.API.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll(Species? species, Size? size, Genre? genre);
    }
}
