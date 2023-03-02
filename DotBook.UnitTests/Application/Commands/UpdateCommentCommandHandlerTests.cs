using DotBook.Application.Commands.UpdateComment;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class UpdateCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnNone()
        {
            // Arrange
            var comment = new Comment("Test", 1, 1);

            var commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(crm => crm.GetByIdAsync(1))
                .ReturnsAsync(comment);

            var updateCommentCommand = new UpdateCommentCommand(1, "Test test");
            var updateCommentCommandHandler = new UpdateCommentCommandHandler(commentRepositoryMock.Object);

            // Act
            await updateCommentCommandHandler.Handle(updateCommentCommand, CancellationToken.None);

            // Assert
            commentRepositoryMock.Verify(crm => crm.GetByIdAsync(1), Times.Once);
            commentRepositoryMock.Verify(crm => crm.SaveChangesAsync(), Times.Once);
            Assert.Equal("Test test", comment.Content);
        }
    }
}
