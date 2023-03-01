using DotBook.Application.Commands.UpdatePublication;
using FluentValidation;

namespace DotBook.Application.Validators
{
    public class UpdatePublicationCommandValidator : AbstractValidator<UpdatePublicationCommand>
    {
        public UpdatePublicationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário informar o id da publicação!");

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("A publicação precisa ser preenchida!");
        }
    }
}
