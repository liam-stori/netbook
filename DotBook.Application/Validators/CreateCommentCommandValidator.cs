using NetBook.Application.Commands.CreateComment;
using FluentValidation;

namespace NetBook.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O comentário");

            RuleFor(c => c.UserId)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O id do usuário");

            RuleFor(c => c.PublicationId)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O id da publicação");
        }
    }
}
