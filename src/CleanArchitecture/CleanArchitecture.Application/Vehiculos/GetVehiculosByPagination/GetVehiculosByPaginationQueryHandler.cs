using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Application.Vehiculos.GetVehiculosByPagination
{
    internal sealed class GetVehiculosByPaginationQueryHandler
    : IQueryHandler<GetVehiculosByPaginationQuery, PaginationResult<Vehiculo, VehiculoId>>
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public GetVehiculosByPaginationQueryHandler(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public Task<Result<PaginationResult<Vehiculo, VehiculoId>>> Handle(
            GetVehiculosByPaginationQuery request,
            CancellationToken cancellationToken)
        {
            // hay que crear una instancia de una especificacion
        }
    }
}
