
using CleanArchitecture.Application.Abstractions.Messaging;

namespace CleanArchitecture.Application.GetAlquiler
{
    public sealed record GetAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;
  
}
