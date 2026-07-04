
namespace CleanArchitecture.Domain.Shared
{
    public record Moneda(decimal Monto, TipoMoneda TipoMoneda)
    {
        // fabrica de moneda Static Factory Method
        public static Moneda operator +(Moneda primero, Moneda segundo)
        {
            if (primero.TipoMoneda != segundo.TipoMoneda)
            {
                throw new InvalidOperationException("El tipo de moneda debe ser el mismo");
            }

            return new Moneda(primero.Monto + segundo.Monto, primero.TipoMoneda);
        }

        // --- CONCEPTO DEL "ZERO" EN MONEDA ---

        // LÓGICA DE NEGOCIO: 
        // 1. Inicializa el saldo de un alquiler en $0 indicando ya la moneda elegida (ej. "0 USD").
        // 2. Sirve como punto de partida para ir sumando las cuotas que pague el cliente.
        // 3. 'IsZero' permite verificar fácilmente si un pago vino vacío o si el saldo ya se liquidó.

        // EXPLICACIÓN TÉCNICA (C#):
        // - 'Zero(TipoMoneda)' es un método fábrica que crea un objeto Moneda con monto 0 y un tipo fuerte.
        // - 'IsZero' es una propiedad calculada (bool) que compara la instancia actual contra un cero 
        //   de su misma moneda usando la comparación por valor nativa de los 'records'.
        // PATRON DE DISEÑO STATIC FACTORY METHOD
        public static Moneda Zero() => new(0, TipoMoneda.None);
        public static Moneda Zero(TipoMoneda tipoMoneda) => new(0, tipoMoneda);
        public bool IsZero() => this == Zero(TipoMoneda);
    }
}
