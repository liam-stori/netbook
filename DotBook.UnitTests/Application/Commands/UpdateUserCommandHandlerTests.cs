using DotBook.Application.Commands.UpdateUser;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class UpdateUserCommandHandlerTests
    {
        [Fact]
        public async Task UpdateDataIsOk_Executed_ReturnNone()
        {
            //Arrange
            var user = new User("Test", "Test", DateTime.Now, "12365478910", "test@test.com", "Teste123@@", "Users");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(urm => urm.GetByIdAsync(1))
                .ReturnsAsync(user);

            var updateUserCommand = new UpdateUserCommand(1, "Test test", "Test test", DateTime.Now, "12345678910");
            var updateUserCommandHandler = new UpdateUserCommandHandler(userRepositoryMock.Object);

            //Act
            await updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

            //Assert
            userRepositoryMock.Verify(urm => urm.GetByIdAsync(1), Times.Once);
            userRepositoryMock.Verify(urm => urm.SaveChangesAsync(), Times.Once);
            Assert.Equal("Test test", user.FirstName);
            Assert.Equal("Test test", user.LastName);
            Assert.Equal("12345678910", user.PhoneNumber);
            Assert.Equal("test@test.com", user.Email);
            Assert.Equal("Teste123@@", user.Password);
            Assert.Equal("Users", user.Role);
        }
    }
}
