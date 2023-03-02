using DotBook.Application.Commands.DeletePublication;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class DeletePublicationCommandHandlerTests
    {
        [Fact]
        public async Task InputIdDeleteIsOk_Executed_ReturnNone()
        {
            //Arrange
            var publication = new Mock<Publication>();

            var publicationMockRepository = new Mock<IPublicationRepository>();
            publicationMockRepository.Setup(pmr => pmr.GetByIdAsync(1)).ReturnsAsync(publication.Object);

            var deletePublicationCommand = new DeletePublicationCommand(1);

            var deletePublicationCommandHandler = new DeletePublicationCommandHandler(publicationMockRepository.Object);

            //Act
            await deletePublicationCommandHandler.Handle(deletePublicationCommand, new CancellationToken());

            //Assert
            publicationMockRepository.Verify(pmr => pmr.GetByIdAsync(1), Times.Once);
            publicationMockRepository.Verify(pmr => pmr.SaveChangesAsync(), Times.Once);
            publication.Verify(p => p.Disabled(), Times.Once);
        }
    }
}
