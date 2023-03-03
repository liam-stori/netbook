using NetBook.Application.Queries.GetUserById;
using NetBook.Core.Entities;
using NetBook.Core.Repositories;
using Moq;

namespace NetBook.UnitTests.Application.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        [Fact]
        public async Task UserExists_Executed_ReturnUserViewModel()
        {
            //Arrange
            var user = new User("Usuário", "Sobrenome", DateTime.Now, "12365478910", "test@test.com", "Teste123@@", "Users");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(urm => urm
                .GetByIdAsync(user.Id).Result)
                .Returns(user);

            var getUserByIdQuery = new GetUserByIdQuery(user.Id);
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

            //Act
            var userViewModel = await getUserByIdQueryHandler.Handle(getUserByIdQuery, new CancellationToken());

            //Assert
            Assert.NotNull(userViewModel);
            Assert.Equal(user.FirstName, userViewModel.FirstName);
            Assert.Equal(user.LastName, userViewModel.LastName);
            Assert.Equal(user.Email, userViewModel.Email);
            Assert.Equal(user.PhoneNumber, userViewModel.PhoneNumber);
            Assert.Equal(user.BirthDate, userViewModel.BirthDate);

            userRepositoryMock.Verify(urm => urm.GetByIdAsync(user.Id), Times.Once());
        }
    }
}
