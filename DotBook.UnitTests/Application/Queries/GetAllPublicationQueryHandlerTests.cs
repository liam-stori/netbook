using DotBook.Application.Queries.GetAllPublication;
using DotBook.Core.DTOs;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Queries
{
    public class GetAllPublicationQueryHandlerTests
    {
        [Fact]
        public async Task FivePublicationExists_Executed_ReturnFivePublicationDTO()
        {
            //Arrange
            var publicationDtos = new List<PublicationDTO>
            {
                new PublicationDTO("Content 1", "Usuário 1"),
                new PublicationDTO ("Content 2", "Usuário 2"),
                new PublicationDTO ("Content 3", "Usuário 3"),
                new PublicationDTO ("Content 4", "Usuário 4"),
                new PublicationDTO ("Content 5", "Usuário 5")
            };

            var publicationRespositoryMock = new Mock<IPublicationRepository>();
            publicationRespositoryMock.Setup(prm => prm
                .GetAllAsync().Result)
                .Returns(publicationDtos);

            var getAllPublicationQuery = new GetAllPublicationQuery();
            var getAllPublicationQueryHandler = new GetAllPublicationQueryHandler(publicationRespositoryMock.Object);

            //Act
            var publicationDtoList = await getAllPublicationQueryHandler.Handle(getAllPublicationQuery, new CancellationToken());

            //Assert
            Assert.NotNull(publicationDtoList);
            Assert.NotEmpty(publicationDtoList);
            Assert.Equal(publicationDtos.Count, publicationDtoList.Count);

            publicationRespositoryMock.Verify(prm => prm.GetAllAsync().Result, Times.Once);
        }
    }
}
