using DotBook.Application.Commands.CreatePublication;
using DotBook.Application.Validators;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class CreatePublicationCommandHandlerTests
    {
        [Fact]
        public async Task CreateDataPublicationIsOk_Executed_ReturnNone()
        {
            //Arrange
            var publicationRepositoryMock = new Mock<IPublicationRepository>();

            var createPublicationCommand = new CreatePublicationCommand
            {
                Content = "Content",
                IdUser = 1
            };
            var createPublicationCommandHandler = new CreatePublicationCommandHandler(publicationRepositoryMock.Object);

            //Act
            await createPublicationCommandHandler.Handle(createPublicationCommand, new CancellationToken());

            //Assert
            publicationRepositoryMock.Verify(pmr => pmr.AddAsync(It.IsAny<Publication>()), Times.Once);
            publicationRepositoryMock.Verify(pmr => pmr.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task CreateDataPublicationContentNull_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createPublicationCommand = new CreatePublicationCommand
            {
                Content = null,
                IdUser = 1
            };
            var validator = new CreatePublicationCommandValidator();

            //Act
            var validationResult = await validator.ValidateAsync(createPublicationCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("'A publicação' deve ser informado.", validationResult.Errors.First().ErrorMessage);
        }

    }
}
