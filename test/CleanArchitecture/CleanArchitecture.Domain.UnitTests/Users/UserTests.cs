using CleanArchitecture.Domain.Users;
using Xunit;

namespace CleanArchitecture.Domain.UnitTests.Users
{
    public class UserTests
    {
        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            // Arrange --> Vamos a crear un Mock File-> UserMock


            // Act
            var user = User.Create(
                UserMock.Nombre,
                UserMock.Apellido,
                UserMock.Email,
                UserMock.Password
            );

            // Assert

        }
    }
}
