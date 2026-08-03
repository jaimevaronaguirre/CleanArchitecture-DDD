namespace CleanArchitecture.Domain.Users
{
    public record UserId(Guid Value)
    {
        // Identificadores Fuertemente Tipados (Strongly Typed IDs) y los Generadores de GUIDs Secuenciales (Sequential GUIDs / COMB GUIDs).
        public static UserId New() => new(Guid.NewGuid());
    }
}
