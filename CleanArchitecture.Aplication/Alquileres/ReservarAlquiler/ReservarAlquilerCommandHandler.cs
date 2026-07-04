using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Application.Alquileres.ReservarAlquiler
{
    public sealed class ReservarAlquilerCommandHandler :
        ICommandHandler<ReservarAlquilerCommand, Guid>
    {

        private readonly IUserRepository _userRepository;
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly PrecioService _precioSevice;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;


        public ReservarAlquilerCommandHandler(
            IUserRepository userRepository,
            IVehiculoRepository ehiculoRepository,
            IAlquilerRepository alquilerRepository,
            PrecioService precioSevice, IUnitOfWork unitOfWork,
            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _vehiculoRepository = ehiculoRepository;
            _alquilerRepository = alquilerRepository;
            _precioSevice = precioSevice;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(
            ReservarAlquilerCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UsuarioId, cancellationToken);
            if(user is null)
            {
                return Result.Failure<Guid>(UserErrors.NotFound);
            }

            var vehiculo = await _vehiculoRepository.GetByIdAsync(request.VehiculoId, cancellationToken);
            if (user is null)
            {
                return Result.Failure<Guid>(VehiculoErrors.NotFound);
            }

            var duracion = DateRange.Create(request.FechaInnicio, request.FechaFin);

            if (await _alquilerRepository.IsOverlappingAsync(vehiculo, duracion, cancellationToken))
            {
                return Result.Failure<Guid>(AlquilerErrors.Overlap);
            }

            var alquiler = Alquiler.Reservar(
                vehiculo,
                user.Id,
                duracion,
                DateTime.UtcNow,
                _precioSevice
            );

            _alquilerRepository.Add( alquiler );

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return alquiler.Id;
        }
    }
}
