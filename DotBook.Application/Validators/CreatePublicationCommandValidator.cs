﻿using DotBook.Application.Commands.CreatePublication;
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
                .OverridePropertyName("A publicação");

            RuleFor(p => p.IdUser)
                .NotEmpty()
                .NotNull()
                .OverridePropertyName("O id do usuário");
        }
    }
}
