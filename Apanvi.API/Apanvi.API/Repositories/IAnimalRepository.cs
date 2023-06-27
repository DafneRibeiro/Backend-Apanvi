using Apanvi.API.Models;

namespace Apanvi.API.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll(Species? species = null, Size? size = null, Genre? genre = null);
        List<Animal> GetByID(int id);
    }
}
