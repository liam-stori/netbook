using DotBook.Application.Commands.UpdateUser;
using FluentValidation;

namespace DotBook.Application.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário informar o id do usuário!");

            RuleFor(u => u.FirstName)
                .MinimumLength(3)
                .WithMessage("O nome deve ser informado e conter ao menos 3 caracteres!");

            RuleFor(u => u.LastName)
                .MinimumLength(3)
                .WithMessage("O sobrenome deve ser informado e conter ao menos 3 caracteres!");

            RuleFor(u => u.BirthDate)
                .NotEmpty()
                .NotNull()
                .WithMessage("A data de nascimento deve ser informada!");

            RuleFor(u => u.PhoneNumber)
                .MinimumLength(10)
                .MaximumLength(12)
                .WithMessage("O telefone deve ser informado com DDD + telefone!");
        }
    }
}
