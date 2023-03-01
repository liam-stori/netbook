using DotBook.Application.Commands.CreateComment;
using FluentValidation;

namespace DotBook.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("O comentário precisa ser preenchido!");

            RuleFor(c => c.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário informar o id do usuário!");

            RuleFor(c => c.PublicationId)
                .NotEmpty()
                .NotNull()
                .WithMessage("É necessário informar o id da publicação!");
        }
    }
}
