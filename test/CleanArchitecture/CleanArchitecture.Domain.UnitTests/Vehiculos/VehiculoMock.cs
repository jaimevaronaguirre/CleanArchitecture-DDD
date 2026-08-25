using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.UnitTests.Vehiculos
{
    internal static class VehiculoMock
    {
        public static Vehiculo Create(Moneda precio, Moneda? mantenimiento = null) 
            => new(
                VehiculoId.New(),
                new Modelo("Corolla"),                
                new Vin("45dsdfds544"),
                precio,
                mantenimiento ?? Moneda.Zero(),
                DateTime.UtcNow.AddYears(-1),
                [],
                new Direccion("USA", "California", "Los Angeles", "El Paso", "Sunset Blvd")

            );
        
       
    }
}
