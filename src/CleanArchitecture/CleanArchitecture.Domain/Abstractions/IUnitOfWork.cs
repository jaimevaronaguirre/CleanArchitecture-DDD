using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        // Guarda en la base de datos la percistencia que este en la memoria temporal de entity framework core y la guarda dentro DB
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
