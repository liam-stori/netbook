using DotBook.Application.Commands.LoginUser;
using DotBook.Application.Services;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataLoginIsOk_Executed_ReturnHash()
        {
            //Arrange
            var user = new User("test", "test", DateTime.Now, "12365498725", "test@test.com", "Teste123@@", "Users");

            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(asm => asm
                .ComputeSha256Hash(user.Password))
                .Returns("hash");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(urm => urm
                .GetByEmailAndPasswordAsync(
                    user.Email, 
                    user.Password))
                .ReturnsAsync(user);

            var loginUserCommand = new LoginUserCommand(user.Email, user.Password);

            var loginUserCommandHandler = new LoginUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            //Act
            await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            //Assert
            authServiceMock.Verify(asm => asm.ComputeSha256Hash(user.Password), Times.Once);
            userRepositoryMock.Verify(urm => urm.GetByEmailAndPasswordAsync(user.Email, "hash"), Times.Once);
        }
    }
}
