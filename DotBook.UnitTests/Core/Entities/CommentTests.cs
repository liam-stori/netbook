using NetBook.Core.Entities;
using NetBook.Core.Enums;

namespace NetBook.UnitTests.Core.Entities
{
    public class CommentTests
    {
        [Fact]
        public void TestIfCommentCreateNotNull()
        {
            var comment = new Comment("Content", 1, 1);

            Assert.NotNull(comment.Content);
        }

        [Fact]
        public void TestIfCommentCreateNotEmpty()
        {
            var comment = new Comment("Content", 1, 1);

            Assert.NotEmpty(comment.Content);
        }

        [Fact]
        public void TestIfCommentCreateOk()
        {
            var comment = new Comment("Content", 1, 1);

            Assert.Equal("Content", comment.Content);
            Assert.Equal(1, comment.UserId);
            Assert.Equal(1, comment.PublicationId);
            Assert.Equal(CommentStatusEnum.Enable, comment.Status);
        }

        [Fact]
        public void TestIfCommentDisabled()
        {
            var comment = new Comment("Content", 1, 1);

            comment.Disabled();
            Assert.Equal(CommentStatusEnum.Disable, comment.Status);
        }

        [Fact]
        public void TestIfCommentUpdateNotNull()
        {
            var comment = new Comment("Content", 1, 1);

            comment.Update("Comment update");

            Assert.NotNull(comment.Content);
        }

        [Fact]
        public void TestIfCommentUpdateNotEmpty()
        {
            var comment = new Comment("Content", 1, 1);

            comment.Update("Comment update");

            Assert.NotEmpty(comment.Content);
        }

        [Fact]
        public void TestIfCommentUpdateOk()
        {
            var comment = new Comment("Content", 1, 1);

            comment.Update("Comment update");

            Assert.Equal("Comment update", comment.Content);
        }
    }
}
