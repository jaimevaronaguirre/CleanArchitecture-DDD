
namespace CleanArchitecture.Domain.Shared
{
    public record TipoMoneda
    {
        // Patron de diseño Type-Safe Enemeration (Enumeracion Segura de Tipos)

        
        //cuando el cliente cotizando y aun no a elige el tipo de moneda (Dolar/Euro)
        // Evita usar null y protege al sistema de caerse si el dato está vacio al inicio
        // patron de diseño Null Object (Objeto nulo) crea un objeto real con la misma estructura que los demas,
        public static readonly TipoMoneda None = new("");
        // actuan como acesos directos a instancias especificas de tu tipo de modenada
        public static readonly TipoMoneda Usd = new("USD");
        public static readonly TipoMoneda Eur = new("EUR");

        // restringe la creacion de nuevos objetos, protegiendo la integridad de el codigo
        private TipoMoneda(string Codigo) => Codigo = Codigo;

        // solo se puede asignar una sola vez con la propiedad init para evitar que puedan crear un nuevo tipo de moneda
        public string? Codigo { get; init; }

        // reune todas las monedas disponibles
        public static readonly IReadOnlyCollection<TipoMoneda> All = new[]
        {
            Usd,
            Eur
        };

        //  y finalmente, la funcion FRomCodigo busca la moneda requerida y, si no existe, genera una exepción para informar
        public static TipoMoneda FromCodigo(string codigo)
        {
            return All.FirstOrDefault(c => c.Codigo == codigo) ??
            throw new ApplicationException("El tipo de moneda es invalido");
        }
    }
   
}
