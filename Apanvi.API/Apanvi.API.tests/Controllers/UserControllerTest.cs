using Apanvi.API.Controllers;
using Apanvi.API.Models;
using Apanvi.API.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Apanvi.API.tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void GetAllUsers_ThenReturnAllUsers()
        {
            // Arrange
            var users = new List<User>()
            {
                new User("Daiana", "SuperAdmin"),
                new User("Renata", "Admin")
            };
            var repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(p => p.GetAll()).Returns(users);

            var sut = new UserController(repositoryMock.Object);
            // Act
            var response = sut.GetAllUsers();
            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            var userResponse = okObjectResult.Value.Should().BeAssignableTo<List<User>>().Subject;
            userResponse.Should().BeSameAs(users);
            repositoryMock.Verify(p => p.GetAll(), Times.Once);

            repositoryMock.VerifyNoOtherCalls();
        }
    }
}
