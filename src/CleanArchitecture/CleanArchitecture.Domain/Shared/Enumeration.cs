namespace CleanArchitecture.Domain.Shared
{
    // Clase base para crear Enumeraciones Inteligentes (Smart Enum).
    // TEnum representa la clase hija que heredará de Enumeration.
    // Ejemplo:
    // public sealed class UserRole : Enumeration<UserRole>
    public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
        where TEnum : Enumeration<TEnum> // Obliga a que TEnum herede de Enumeration<TEnum>
    {
        // Diccionario que almacena todas las instancias de la enumeración.
        //
        // Clave (Key)   -> Id de la enumeración
        // Valor (Value) -> Objeto completo de la enumeración
        //
        // Ejemplo:
        // 1 -> UserRole.Admin
        // 2 -> UserRole.Member
        //
        // Se llena automáticamente llamando al método CreateEnumerations().
        private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

        // Identificador único de la enumeración.
        public int Id { get; protected init; }

        // Nombre de la enumeración.
        public string? Name { get; protected init; }

        // Constructor.
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Busca una enumeración utilizando su Id.
        //
        // Ejemplo:
        // UserRole.FromValue(1)
        //
        // Internamente usa el diccionario para hacer la búsqueda en tiempo O(1).
        public static TEnum? FromValue(int id)
        {
            // TryGetValue devuelve true si encontró el Id.
            // Si existe, devuelve la enumeración.
            // Si no existe devuelve null.
            return Enumerations.TryGetValue(id, out TEnum? enumeration)
                ? enumeration
                : default;
        }

        // Busca una enumeración por el nombre.
        //
        // Ejemplo:
        // UserRole.FromName("Admin")
        //
        // Recorre todos los valores del diccionario hasta encontrar coincidencia.
        public static TEnum? FromName(string name)
        {
            return Enumerations.Values
                .SingleOrDefault(x => x.Name == name);
        }

        // Devuelve una lista con todas las enumeraciones existentes.
        //
        // Ejemplo:
        // [Admin, Member, Guest]
        public static List<TEnum> GetValues()
        {
            return Enumerations.Values.ToList();
        }

        // Compara dos enumeraciones.
        //
        // Dos enumeraciones son iguales cuando:
        // 1. Son del mismo tipo.
        // 2. Tienen el mismo Id.
        public bool Equals(Enumeration<TEnum>? other)
        {
            if (other is null)
            {
                return false;
            }

            return GetType() == other.GetType()
                && Id == other.Id;
        }

        // Sobrescribe Equals de object.
        // Permite que el operador Equals funcione correctamente.
        public override bool Equals(object? obj)
        {
            return obj is Enumeration<TEnum> other
                && Equals(other);
        }

        // Devuelve un código hash basado únicamente en el Id.
        // Es necesario para que Dictionary, HashSet y otras colecciones funcionen correctamente.
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        // Cuando imprimimos la enumeración,
        // por ejemplo:
        //
        // Console.WriteLine(UserRole.Admin);
        //
        // se mostrará "Admin".
        public override string ToString()
        {
            return Name!;
        }

        // Este método crea automáticamente todas las enumeraciones existentes.
        //
        // Utiliza Reflection para inspeccionar la clase hija y encontrar
        // todos los campos públicos y estáticos.
        //
        // Ejemplo:
        //
        // public sealed class UserRole : Enumeration<UserRole>
        // {
        //     public static readonly UserRole Admin = new(1,"Admin");
        //     public static readonly UserRole Member = new(2,"Member");
        // }
        //
        // Reflection encuentra automáticamente Admin y Member.
        public static Dictionary<int, TEnum> CreateEnumerations()
        {
            // Obtiene el tipo concreto.
            //
            // Ejemplo:
            // typeof(UserRole)
            var enumerationType = typeof(TEnum);

            // Reflection obtiene todos los campos:
            // public static readonly ...
            var fieldsForType = enumerationType.GetFields(
                    System.Reflection.BindingFlags.Public |      // Públicos
                    System.Reflection.BindingFlags.Static |      // Estáticos
                    System.Reflection.BindingFlags.FlattenHierarchy // Incluye la jerarquía
                )

                // Conserva únicamente aquellos campos cuyo tipo sea TEnum.
                .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))

                // Obtiene el valor real del campo.
                //
                // Convierte:
                // FieldInfo
                //
                // en
                //
                // UserRole.Admin
                .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);

            // Finalmente construye un diccionario.
            //
            // Antes:
            //
            // Admin
            // Member
            //
            // Después:
            //
            // 1 -> Admin
            // 2 -> Member
            return fieldsForType.ToDictionary(x => x.Id);
        }
    }
}