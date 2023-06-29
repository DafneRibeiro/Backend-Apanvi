using Apanvi.API.Models;
using Apanvi.API.Repositories;
using FluentAssertions;


namespace Apanvi.API.tests.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void GetAll_ThenReturnAllUsers()
        {
            // Arrange
            var sut = new UserRepository(); 

            //Act
            var users = sut.GetAll();

            // Assert
            users.Should().HaveCount(2)
                .And.BeEquivalentTo(AllUsers());
        }

        private List<User> AllUsers()
        {
            return new List<User>()
            {
                new User("Daiana", "SuperAdmin"),
                new User("Renata", "Admin")
            };
            
        }
    }
}
