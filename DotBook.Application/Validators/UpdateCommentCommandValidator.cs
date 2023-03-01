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
                .WithMessage("É necessário informar o id do comentário!");

            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("O comentário precisa ser preenchido!");
        }
    }
}
