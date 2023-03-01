using DotBook.Application.Commands.CreatePublication;
using FluentValidation;

namespace DotBook.Application.Validators
{
    public class CreatePublicationCommandValidator : AbstractValidator<CreatePublicationCommand>
    {
        public CreatePublicationCommandValidator()
        {
            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("A publicação precisa ser preenchida!");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário informar o id do usuário!");
        }
    }
}
