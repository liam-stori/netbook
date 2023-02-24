using DotBook.Core.Enums;

namespace DotBook.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;

            Status = UserStatusEnum.Enabled;

            Publications = new List<Publication>();
            Comments = new List<PublicationComment>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public List<Publication> Publications { get; private set; }
        public List<PublicationComment> Comments { get; private set; }

        public void DisabledAccount()
        {
            Status = UserStatusEnum.Disabled;
        }
    }
}
