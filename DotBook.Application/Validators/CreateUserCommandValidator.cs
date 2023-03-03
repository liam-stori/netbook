using NetBook.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace NetBook.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FirstName)
                .MinimumLength(3)
                .WithMessage("O nome deve ser informado e conter ao menos 3 caracteres.");

            RuleFor(u => u.LastName)
                .MinimumLength(3)
                .WithMessage("O sobrenome deve ser informado e conter ao menos 3 caracteres.");

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("Data de nascimento");

            RuleFor(u => u.PhoneNumber)
                .MinimumLength(10)
                .MaximumLength(12)
                .OverridePropertyName("O telefone");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("O e-mail informado não é válido.");

            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma letra minúscula e um caractere especial.");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}
