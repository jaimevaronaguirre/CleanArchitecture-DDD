namespace CleanArchitecture.Domain.Users;

public interface IUserRepository
{
    // Los metodos GetByIdAsync y Add son metodos genericos y se implementan para todas las entidades en el Repository para que cualquier entidad lo pueda usar
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);    
    void Add(User user);
    // El metodo GetByEmailAsync es un metodo personalizado para buscar un usuario por su email para la validacion de credenciales
    Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<bool> IsUserExistsAsync(Email email, CancellationToken cancellationToken = default);

}