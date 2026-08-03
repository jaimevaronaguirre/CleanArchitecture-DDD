using FluentValidation;

namespace CleanArchitecture.Application.Common.Validation
{
    public static class ValidationMessages
    {
        // Comunes
        public const string Required = "El campo es obligatorio.";
        public const string InvalidFormat = "El formato no es válido.";

        // Usuario
        public const string NameRequired = "El nombre es obligatorio.";
        public const string LastNameRequired = "El apellido es obligatorio.";
        public const string EmailRequired = "El correo es obligatorio.";
        public const string FormatInvalidEmail = "El correo no es válido.";
        public const string PasswordRequired = "La contraseña es obligatoria.";
        public const string PasswordTooShort = "La contraseña debe tener al menos 5 caracteres.";

        // Vehículo
        public const string PlateRequired = "La placa es obligatoria.";
        public const string InvalidPlate = "La placa no tiene un formato válido.";

        // Alquiler
        public const string StartDateRequired = "La fecha de inicio es obligatoria.";
        public const string EndDateRequired = "La fecha de fin es obligatoria.";
    }
}
