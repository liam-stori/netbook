using DotBook.Application.Commands.UpdatePublication;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class UpdatePublicationCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnNone()
        {
            //Arrange
            var publication = new Publication("Test", 1);

            var publicationRepositoryMock = new Mock<IPublicationRepository>();
            publicationRepositoryMock.Setup(prm => prm.GetByIdAsync(1))
                .ReturnsAsync(publication);

            var updatePublicationCommand = new UpdatePublicationCommand(1, "Test test");
            var updatePublicationCommandHandler = new UpdatePublicationCommandHandler(publicationRepositoryMock.Object);

            //Act
            await updatePublicationCommandHandler.Handle(updatePublicationCommand, new CancellationToken());

            //Assert
            publicationRepositoryMock.Verify(prm => prm.GetByIdAsync(1), Times.Once);
            publicationRepositoryMock.Verify(prm => prm.SaveChangesAsync(), Times.Once);
            Assert.Equal("Test test", publication.Content);
        }
    }
}
