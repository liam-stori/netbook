using DotBook.Core.Entities;
using DotBook.Core.Enums;

namespace DotBook.UnitTests.Core.Entities
{
    public class PublicationTests
    {
        [Fact]
        public void TestIfPublicationCreateNotNull()
        {
            var publication = new Publication("Content", 1);

            Assert.NotNull(publication.Content);
        }

        [Fact]
        public void TestIfPublicationCreateNotEmpty()
        {
            var publication = new Publication("Content", 1);

            Assert.NotEmpty(publication.Content);
        }

        [Fact]
        public void TestIfPublicationCreateOk()
        {
            var publication = new Publication("Content", 1);

            Assert.Equal("Content", publication.Content);
            Assert.Equal(1, publication.UserId);
            Assert.Equal(PublicationStatusEnum.Enable, publication.Status);
        }

        [Fact]
        public void TestIfPublicationDisabled()
        {
            var publication = new Publication("Content", 1);

            publication.Disabled();
            Assert.Equal(PublicationStatusEnum.Disable, publication.Status);
        }

        [Fact]
        public void TestIfPublicationUpdateNotNull()
        {
            var publication = new Publication("Content", 1);

            Assert.NotNull(publication.Content);
        }

        [Fact]
        public void TestIfPublicationUpdateNotEmpty()
        {
            var publication = new Publication("Content", 1);

            Assert.NotEmpty(publication.Content);
        }

        [Fact]
        public void TestIfPublicationUpdateOk()
        {
            var publication = new Publication("Content", 1);

            publication.Update("Content update");

            Assert.Equal("Content update", publication.Content);
        }
    }
}
