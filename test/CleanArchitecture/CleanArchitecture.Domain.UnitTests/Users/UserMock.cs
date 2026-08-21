using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Domain.UnitTests.Users
{
    internal class UserMock
    {
        public static readonly Nombre Nombre = new Nombre("John");
        public static readonly Apellido Apellido = new Apellido("Doe");
        public static readonly Email Email = new Email("john@example.com");
        public static readonly PasswordHash Password = new PasswordHash("Test@123");
    }
}
