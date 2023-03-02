using DotBook.Application.Commands.UpdateComment;
using FluentValidation;

namespace DotBook.Application.Validators
{
    public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O id do comentário");

            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O comentário");
        }
    }
}
