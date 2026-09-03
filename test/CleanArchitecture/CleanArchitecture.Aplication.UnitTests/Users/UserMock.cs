using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.UnitTests.Users
{
    internal static class UserMock
    {
        public static User Create() => User.Create(
            Nombre,
            Apellido,
            Email,
            Password
        );
        public static readonly Nombre Nombre = new("Moises");
        public static readonly Apellido Apellido = new("Varon Hernandez");
        public static readonly Email Email = new("moisesvaron@gmail.com");
        public static readonly PasswordHash Password = new("AfED%%32111");
    }
}
