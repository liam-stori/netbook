using DotBook.Application.Commands.EnableUser;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class EnableUserCommandHandlerTests
    {
        [Fact]
        public async Task InputIdEnableAccountIsOk_Executed_ReturnNone()
        {
            //Arrange
            var user = new Mock<User>();

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(urm => urm.GetByIdAsync(1)).ReturnsAsync(user.Object);

            var enableUserCommand = new EnableUserCommand(1);

            var enableUserCommandHandler = new EnableUserCommandHandler(userRepositoryMock.Object);

            //Act
            await enableUserCommandHandler.Handle(enableUserCommand, new CancellationToken());
            user.Object.DisabledAccount();

            //Assert
            userRepositoryMock.Verify(urm => urm.GetByIdAsync(1), Times.Once);
            userRepositoryMock.Verify(urm => urm.SaveChangesAsync(), Times.Once);
            Assert.False(user.Object.Status.Equals(0));
        }
    }
}
