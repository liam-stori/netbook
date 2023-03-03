namespace NetBook.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
