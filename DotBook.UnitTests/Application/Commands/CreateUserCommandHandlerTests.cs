using NetBook.Application.Commands.CreateUser;
using NetBook.Application.Services;
using NetBook.Application.Validators;
using NetBook.Core.Entities;
using NetBook.Core.Repositories;
using Moq;

namespace NetBook.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task CreateDataUserIsOk_Executed_ReturnNone()
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
            userRepositoryMock.Verify(umr => umr.AddAsync(It.IsAny<User>()), Times.Once);
            userRepositoryMock.Verify(umr => umr.SaveChangesAsync(), Times.Once);
            authServiceMock.Verify(asm => asm.ComputeSha256Hash(createUserCommand.Password), Times.Once);
        }

        [Fact]
        public async Task CreateDataUserFirstNameNotMinimumLength_Executed_ReturnValidatorMessage()
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
        public async Task CreateDataUserLastNameNotMinimumLength_Executed_ReturnValidatorMessage()
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
        public async Task CreateDataUserPhoneNumberNotMinimumLength_Executed_ReturnValidatorMessage()
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
        public async Task CreateDataUserPhoneNumberNotMaximumLength_Executed_ReturnValidatorMessage()
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
        public async Task CreateDataUserEmailNotValid_Executed_ReturnValidatorMessage()
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
        public async Task CreateDataUserPasswordNotValid_Executed_ReturnValidatorMessage()
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
