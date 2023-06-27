using Apanvi.API.Controllers;
using Apanvi.API.Models;
using Apanvi.API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Apanvi.API.tests.Controllers
{
    public class AnimalControllerTest
    {
        [Theory]
        [InlineData(Species.Dog, Size.Small, Genre.Female)]
        public void GetAll_WhenNoFilter_ThenReturnAll(Species species, Size size, Genre genre)
        {
            // Arrange
            var animals = new List<Animal>()
            {
                new Animal()
            };
            var repositoryMock = new Mock<IAnimalRepository>();
            repositoryMock.Setup(p => p.GetAll(species, size, genre)).Returns(animals); 
            // instancia a interface usando mock, precisamos passar os props na interface pra retornar os animals(lista de animais)
            var sut = new AnimalController(repositoryMock.Object); 
            //recebe a interface q instanciamos, quando usamos mock ele nao retorna objeto e como ele nao retorna temos que usar .object

            // Act
            var response = sut.GetAnimals(species, size, genre); // esta se referindo a funcao criada no controller
            
            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            // certificar que ele esta retornando um objeto, conferindo se a linha 24 funcionou. Verificar o que .Subject ???
            var animalResponse = okObjectResult.Value.Should().BeAssignableTo<List<Animal>>().Subject;
            // transforma um objeto em uma lista 
            animalResponse.Should().BeSameAs(animals); // testando GetAnimals
            repositoryMock.Verify(p => p.GetAll(It.IsAny<Species?>(), It.IsAny<Size?>(), It.IsAny<Genre?>()), Times.Once); // passamos o ? pq ela pode ser null
            // verifica se o mock ta funcionando, se esta retornando o resultado corretamente 
            repositoryMock.VerifyNoOtherCalls(); // verifica se ele instacia somente uma vez
        }
    }
}
