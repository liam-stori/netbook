using DotBook.Core.Enums;
using System.Collections.ObjectModel;

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

            Publications = new Collection<Publication>();
            Comments = new Collection<PublicationComment>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserStatusEnum Status { get; private set; }
        public ICollection<Publication> Publications { get; private set; }
        public ICollection<PublicationComment> Comments { get; private set; }

        public void DisabledAccount()
        {
            Status = UserStatusEnum.Disabled;
        }
    }
}
