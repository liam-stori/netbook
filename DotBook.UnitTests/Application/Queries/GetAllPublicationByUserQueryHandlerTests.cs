using DotBook.Application.Queries.GetAllPublication;
using DotBook.Core.DTOs;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Queries
{
    public class GetAllPublicationByUserQueryHandlerTests
    {
        [Fact]
        public async Task TwoPublicationExists_Executed_ReturnTwoPublicationDTO()
        {
            //Arrange
            var user = new User("Usuário 1", "test", DateTime.Now, "1236547891", "test@test.com", "Teste123@@", "Users");
    
            var publicationDtos = new List<PublicationDTO>
            {
                new PublicationDTO("Content 1", "Usuário 1"),
                new PublicationDTO("Content 2", "Usuário 1")
            };

            var publicationRepositoryMock = new Mock<IPublicationRepository>();
            publicationRepositoryMock.Setup(prm => prm
                .GetAllByUserIdAsync(user.Id).Result).Returns(publicationDtos);

            var getAllPublicationByUserQuery = new GetAllPublicationByUserQuery(user.Id);
            var getAllPublicationByUserQueryHandler = new GetAllPublicationByUserQueryHandler(publicationRepositoryMock.Object);

            //Act
            var publicationDtoList = await getAllPublicationByUserQueryHandler.Handle(getAllPublicationByUserQuery, new CancellationToken());

            //Assert
            Assert.NotNull(publicationDtoList);
            Assert.NotEmpty(publicationDtoList);
            Assert.Equal(publicationDtos.Count, publicationDtoList.ToList().Count);

            publicationRepositoryMock.Verify(prm => prm.GetAllByUserIdAsync(user.Id), Times.Once);
        }
    }
}
