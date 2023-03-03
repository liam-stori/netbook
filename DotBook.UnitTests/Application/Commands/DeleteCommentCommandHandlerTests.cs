using NetBook.Application.Commands.DeleteComment;
using NetBook.Core.Entities;
using NetBook.Core.Repositories;
using Moq;

namespace NetBook.UnitTests.Application.Commands
{
    public class DeleteCommentCommandHandlerTests
    {
        [Fact]
        public async Task InputIdDeleteIsOk_Executed_ReturnNone()
        {
            //Arrange
            var comment = new Mock<Comment>();

            var commentRepositoryMock = new Mock<ICommentRepository>();
            commentRepositoryMock.Setup(crm => crm.GetByIdAsync(1)).ReturnsAsync(comment.Object);

            var deleteCommentCommand = new DeleteCommentCommand(1);

            var deleteCommentCommandHandler = new DeleteCommentCommandHandler(commentRepositoryMock.Object);

            //Act
            await deleteCommentCommandHandler.Handle(deleteCommentCommand, new CancellationToken());

            //Assert
            commentRepositoryMock.Verify(cmr => cmr.GetByIdAsync(1), Times.Once);
            commentRepositoryMock.Verify(cmr => cmr.SaveChangesAsync(), Times.Once);
            comment.Verify(c => c.Disabled(), Times.Once);
        }
    }
}
