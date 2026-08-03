
using FluentValidation;

namespace CleanArchitecture.Application.Common.Validation
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> RequiredName<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(ValidationMessages.NameRequired);
        }
        public static IRuleBuilderOptions<T, string> RequiredLastName<T>(
           this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(ValidationMessages.LastNameRequired);
        }

        public static IRuleBuilderOptions<T, string> RequiredEmail<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(ValidationMessages.EmailRequired);
        }
        public static IRuleBuilderOptions<T, string> InvalidEmail<T>(
           this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(ValidationMessages.FormatInvalidEmail);
        }
        public static IRuleBuilderOptions<T, string> ShortPassword<T>(
          this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(ValidationMessages.PasswordTooShort);
        }
    }
}
    
