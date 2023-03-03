using NetBook.Application.Commands.UpdatePublication;
using FluentValidation;

namespace NetBook.Application.Validators
{
    public class UpdatePublicationCommandValidator : AbstractValidator<UpdatePublicationCommand>
    {
        public UpdatePublicationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O id da publicação");

            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("A publicação");
        }
    }
}
