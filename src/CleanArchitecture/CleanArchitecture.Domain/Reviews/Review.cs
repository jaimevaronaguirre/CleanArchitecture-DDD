using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Reviews.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Reviews
{
    public sealed class Review: Entity
    {
        // se crea un constructor privado para no crear instancias fuera de esta clase
        private Review(
            Guid id,
            Guid vehiculoId,
            Guid alquilerId,
            Guid userId,
            Rating rating,
            Comentario comentario,
            DateTime? fechaCreacion): base(id)
        {
            VehiculoId = vehiculoId;
            AlquilerId = alquilerId;
            UserId = userId;
            Rating = rating;
            Comentario = comentario;
            FechaCreacion = fechaCreacion;
        }

        public Guid VehiculoId { get; private set; }
        public Guid AlquilerId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Comentario? Comentario { get; private set; }
        public DateTime? FechaCreacion { get; private set; }

        public static Result<Review> Create(
            Alquiler alquiler,
            Rating rating,
            Comentario comentario,
            DateTime fechaCreacion

        )
        {
            if (alquiler.Status != AlquilerStatus.Completado)
            {
                return Result.Failure<Review>(ReviewError.NotElegible);
            }

            var review = new Review(
                Guid.NewGuid(),
                alquiler.VehiculoId,
                alquiler.Id,
                alquiler.UserId,
                rating,
                comentario,
                fechaCreacion
            );

            review.RaiseDomainEvent(new ReviewCreateDomainEvent(review.Id));

            return review;
        }
    }
}
