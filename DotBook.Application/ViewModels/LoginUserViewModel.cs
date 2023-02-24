namespace DotBook.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
