using Apanvi.API.Repositories;
using FluentAssertions;
using Apanvi.API.Models;



namespace Apanvi.API.tests.Repositories
{
    public class AnimalRepositoryTest
    {
        [Fact]
        public void GetAll_WhenNoFilter_ThenReturnAll()
        {
            // Arrange
            var sut = new AnimalRepository();
            // Act
            var animals = sut.GetAll();
            // Assert
            animals.Should().BeEquivalentTo(AllAnimals())
            .And.HaveCount(3);
        }

        [Theory]
        [InlineData(Species.Cat)]
        [InlineData(Species.Dog)]
        public void GetAll_WhenFilteredBySpecies_ThenReturnFiltered(Species species)
        {
            // Arrange
            var sut = new AnimalRepository();
            // Act
            var animals = sut.GetAll(species);
            // Assert
            var animalsBySpecies = AllWithSpecies(species);
            animals.Should().BeEquivalentTo(animalsBySpecies);
            animals.Should().HaveCount(animalsBySpecies.Count);
        }

        [Theory]
        [InlineData(Size.Small)]
        [InlineData(Size.Medium)]
        [InlineData(Size.Large)]
        public void GetAll_WhenFilteredBySize_ThenReturnFiltered(Size size)
        {
            // Arrange
            var sut1 = new AnimalRepository();
            // Act
            var animals = sut1.GetAll(Species.Dog, size);
            // Assert
            var animalsBySize = AllWithSize(size);
            animals.Should().BeEquivalentTo(animalsBySize);
            animals.Should().HaveCount(animalsBySize.Count);
        }

        [Theory]
        [InlineData(Genre.Male)]
        [InlineData(Genre.Female)]

        public void GetAll_WhenFilteredByGenre_ThenReturnFiltered(Genre genre)
        {
            // Arrange
            var sut = new AnimalRepository();
            // Act
            var animals = sut.GetAll(genre: genre);
            // Assert
            var animalsByGenre = AllWithGenre(genre);
            animals.Should().BeEquivalentTo(animalsByGenre);
            animals.Should().HaveCount(animalsByGenre.Count);
        }

        private List<Animal> AllWithSpecies(Species species)
        {
            return AllAnimals().Where(animal => animal.Species == species).ToList();
        }
        private List<Animal> AllWithSize(Size size)
        {
            return AllAnimals().Where(animal => animal.Size == size).ToList();
        }

        private List<Animal> AllWithGenre(Genre genre)
        {
            return AllAnimals().Where(animal => animal.Genre == genre).ToList();
        }


        private List<Animal> AllAnimals()
        {
            return new List<Animal>()
            {
                new Animal
                {
                    Name = "name",
                    Description = "description",
                    Size = Size.Small,
                    Species = Species.Cat,
                    Genre = Genre.Male,
                },
                new Animal
                {
                    Name = "name",
                    Description = "description",
                    Size = Size.Large,
                    Species = Species.Dog,
                    Genre = Genre.Female,
                },

                new Animal
                {
                    Name = "name",
                    Description = "description",
                    Size = Size.Medium,
                    Species = Species.Dog,
                    Genre = Genre.Female,
                }
            };
        }
    }
}
