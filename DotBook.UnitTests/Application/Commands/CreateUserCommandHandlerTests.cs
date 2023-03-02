using DotBook.Application.Commands.CreateUser;
using DotBook.Application.Services;
using DotBook.Application.Validators;
using DotBook.Core.Entities;
using DotBook.Core.Repositories;
using Moq;

namespace DotBook.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task InputDataUserIsOk_Executed_ReturnNone()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateTime.Now,
                PhoneNumber = "1234567891",
                Email = "test@teste.com",
                Password = "Password123@@",
                Role = "Users"
            };
            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            //Act
            await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()), Times.Once());
            userRepositoryMock.Verify(ur => ur.SaveChangesAsync(), Times.Once());
            authServiceMock.Verify(a => a.ComputeSha256Hash(createUserCommand.Password), Times.Once());
        }

        [Fact]
        public async Task InputDataUserFirstNameNotMinimumLength_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "a",
                LastName = "Test",
                BirthDate = DateTime.Now,
                PhoneNumber = "1234567891",
                Email = "test@teste.com",
                Password = "Password123@@",
                Role = "Users"
            };
            var validator = new CreateUserCommandValidator();

            //Act
            var validationResult = await validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("O nome deve ser informado e conter ao menos 3 caracteres.", validationResult.Errors.First().ErrorMessage);
        }

        [Fact]
        public async Task InputDataUserLastNameNotMinimumLength_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "a",
                BirthDate = DateTime.Now,
                PhoneNumber = "1234567891",
                Email = "test@teste.com",
                Password = "Password123@@",
                Role = "Users"
            };
            var validator = new CreateUserCommandValidator();

            //Act
            var validationResult = await validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("O sobrenome deve ser informado e conter ao menos 3 caracteres.", validationResult.Errors.First().ErrorMessage);
        }

        [Fact]
        public async Task InputDataUserPhoneNumberNotMinimumLength_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateTime.Now,
                PhoneNumber = "1234",
                Email = "test@teste.com",
                Password = "Password123@@",
                Role = "Users"
            };
            var validator = new CreateUserCommandValidator();

            int cont = createUserCommand.PhoneNumber.Length;

            //Act
            var validationResult = await validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal($"'O telefone' deve ser maior ou igual a 10 caracteres. Você digitou {cont} caracteres.", validationResult.Errors.First().ErrorMessage);
        }

        [Fact]
        public async Task InputDataUserPhoneNumberNotMaximumLength_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateTime.Now,
                PhoneNumber = "1234113256962177651332189",
                Email = "test@teste.com",
                Password = "Password123@@",
                Role = "Users"
            };
            var validator = new CreateUserCommandValidator();

            int cont = createUserCommand.PhoneNumber.Length;

            //Act
            var validationResult = await validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal($"'O telefone' deve ser menor ou igual a 12 caracteres. Você digitou {cont} caracteres.", validationResult.Errors.First().ErrorMessage);
        }

        [Fact]
        public async Task InputDataUserEmailNotValid_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateTime.Now,
                PhoneNumber = "1478523691",
                Email = "test",
                Password = "Password123@@",
                Role = "Users"
            };
            var validator = new CreateUserCommandValidator();
            //Act
            var validationResult = await validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("O e-mail informado não é válido.", validationResult.Errors.First().ErrorMessage);
        }

        [Fact]
        public async Task InputDataUserPasswordNotValid_Executed_ReturnValidatorMessage()
        {
            //Arrange
            var createUserCommand = new CreateUserCommand
            {
                FirstName = "Test",
                LastName = "Test",
                BirthDate = DateTime.Now,
                PhoneNumber = "1478523691",
                Email = "test@teste.com",
                Password = "Pass",
                Role = "Users"
            };
            var validator = new CreateUserCommandValidator();
            //Act
            var validationResult = await validator.ValidateAsync(createUserCommand);

            //Assert
            Assert.False(validationResult.IsValid);
            Assert.Equal("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma letra minúscula e um caractere especial.", validationResult.Errors.First().ErrorMessage);
        }
    }
}
