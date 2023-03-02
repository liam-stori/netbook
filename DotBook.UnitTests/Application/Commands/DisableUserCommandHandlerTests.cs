using DotBook.Application.Commands.DeleteUser;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class DisableUserCommandHandlerTests
    {
        [Fact]
        public async Task InputIdDisableAccountIsOk_Executed_ReturnNone()
        {
            //Arrange
            var user = new Mock<User>();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(urm => urm.GetByIdAsync(1)).ReturnsAsync(user.Object);

            var disableUserCommand = new DisableUserCommand(1);

            var disableUserCommandHandler = new DisableUserCommandHandler(userRepositoryMock.Object);

            //Act
            await disableUserCommandHandler.Handle(disableUserCommand, new CancellationToken());

            //Assert
            userRepositoryMock.Verify(urm => urm.GetByIdAsync(1), Times.Once);
            userRepositoryMock.Verify(urm => urm.SaveChangesAsync(), Times.Once);
            user.Verify(u => u.DisabledAccount(), Times.Once);
        }
    }
}
