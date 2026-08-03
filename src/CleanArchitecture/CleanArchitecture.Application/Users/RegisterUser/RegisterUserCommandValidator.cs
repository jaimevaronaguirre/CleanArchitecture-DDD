using CleanArchitecture.Application.Common.Validation;
using FluentValidation;


namespace CleanArchitecture.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.Nombre).NotEmpty().RequiredName();
            RuleFor(c => c.Apellido).NotEmpty().RequiredLastName();
            RuleFor(c => c.Email).EmailAddress().InvalidEmail();
            RuleFor(c => c.Password).NotEmpty().ShortPassword();
        }
    }
}
