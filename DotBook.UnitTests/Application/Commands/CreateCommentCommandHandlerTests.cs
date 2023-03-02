using DotBook.Application.Commands.CreateComment;
using DotBook.Application.Validators;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class CreateCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataCommentIsOk_Executed_ReturnNone()
        {
            //Arrange
            var commentRepositoryMock = new Mock<ICommentRepository>();

            var createCommentCommand = new CreateCommentCommand
            {
                Content = "Content test",
                UserId = 1,
                PublicationId = 1
            };
            var createCommentCommandHandler = new CreateCommentCommandHandler(commentRepositoryMock.Object);

            //Act
            await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());

            //Assert
            commentRepositoryMock.Verify(cr => cr.AddAsync(It.IsAny<Comment>()), Times.Once());
            commentRepositoryMock.Verify(cr => cr.SaveChangesAsync(), Times.Once());
        }

        [Fact]
        public async Task InputDataCommentContentNull_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createCommentCommand = new CreateCommentCommand
            {
                Content = null,
                UserId = 1,
                PublicationId = 1
            };
            var validator = new CreateCommentCommandValidator();

            //Act
            var validationResult = await validator.ValidateAsync(createCommentCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("'O comentário' deve ser informado.", validationResult.Errors.First().ErrorMessage);
        }      
    }
}
