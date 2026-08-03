using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<User>()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> IsUserExistsAsync(Email email, CancellationToken cancellationToken = default)
    {
        // Valida si ya existe un usuario registrado con el correo electrónico especificado.
        // AnyAsync retorna true si encuentra al menos una coincidencia.
        return await DbContext.Set<User>()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }
}