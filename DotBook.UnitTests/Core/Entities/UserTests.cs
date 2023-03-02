using DotBook.Core.Entities;
using DotBook.Core.Enums;

namespace DotBook.UnitTests.Core.Entities
{
    public class UserTests
    {

        [Fact]
        public void TestIfUserCreateNotNull()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            Assert.NotNull(user.FirstName);
            Assert.NotNull(user.LastName);
            Assert.NotNull(user.PhoneNumber);
            Assert.NotNull(user.Email);
            Assert.NotNull(user.Password);
            Assert.NotNull(user.Role);
        }

        [Fact]
        public void TestIfUserCreateNotEmpty()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            Assert.NotEmpty(user.FirstName);
            Assert.NotEmpty(user.LastName);
            Assert.NotEmpty(user.PhoneNumber);
            Assert.NotEmpty(user.Email);
            Assert.NotEmpty(user.Password);
            Assert.NotEmpty(user.Role);
        }

        [Fact]
        public void TestIfUserCreateOk()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            Assert.Equal("Nome", user.FirstName);
            Assert.Equal("Sobrenome", user.LastName);
            Assert.Equal(new DateTime(2022, 03, 01, 10, 30, 00), user.BirthDate);
            Assert.Equal("1234567891", user.PhoneNumber);
            Assert.Equal("tests@tests.com", user.Email);
            Assert.Equal("Teste123@@", user.Password);
            Assert.Equal("Users", user.Role);
            Assert.Equal(UserStatusEnum.Enabled, user.Status);
        }

        [Fact]
        public void TestIfUserDisabled()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            user.DisabledAccount();
            Assert.Equal(UserStatusEnum.Disabled, user.Status);
        }

        [Fact]
        public void TestIfUserEnabled()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            user.DisabledAccount();
            user.EnableAccount();
            Assert.Equal(UserStatusEnum.Enabled, user.Status);
        }

        [Fact]
        public void TestIfUserUpdateNotNull()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            user.Update("Nome Update", "Sobrenome Update", new DateTime(2023, 02, 01, 15, 30, 0), "1478523691");

            Assert.NotNull(user.FirstName);
            Assert.NotNull(user.LastName);
            Assert.NotNull(user.PhoneNumber);
            Assert.NotNull(user.Email);
            Assert.NotNull(user.Password);
            Assert.NotNull(user.Role);
        }

        [Fact]
        public void TestIfUserUpdateNotEmpty()
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            user.Update("Nome Update", "Sobrenome Update", new DateTime(2023, 02, 01, 15, 30, 0), "1478523691");

            Assert.NotEmpty(user.FirstName);
            Assert.NotEmpty(user.LastName);
            Assert.NotEmpty(user.PhoneNumber);
            Assert.NotEmpty(user.Email);
            Assert.NotEmpty(user.Password);
            Assert.NotEmpty(user.Role);
        }

        [Fact]
        public void TestIfUserUpdateOk() 
        {
            var user = new User("Nome", "Sobrenome", new DateTime(2022, 03, 01, 10, 30, 00, DateTimeKind.Utc), "1234567891", "tests@tests.com", "Teste123@@", "Users");

            user.Update("Nome Update", "Sobrenome Update", new DateTime(2023, 02, 01, 15, 30, 0), "1478523691");

            Assert.Equal("Nome Update", user.FirstName);
            Assert.Equal("Sobrenome Update", user.LastName);
            Assert.Equal(new DateTime(2023, 02, 01, 15, 30, 0), user.BirthDate);
            Assert.Equal("1478523691", user.PhoneNumber);
            Assert.Equal("tests@tests.com", user.Email);
            Assert.Equal("Teste123@@", user.Password);
            Assert.Equal("Users", user.Role);
            Assert.Equal(UserStatusEnum.Enabled, user.Status);
        }
    }
}
