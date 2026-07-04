using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Reviews
{
    public static class ReviewError
    {
        public static readonly Error NotElegible = new Error(
            "Review.NotElegible",
            "Este review y calificación para el auto no es elegible por que aun no se completa"
        );
    }    
    
}
