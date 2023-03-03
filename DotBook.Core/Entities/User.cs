using NetBook.Core.Enums;
using System.Collections.ObjectModel;

namespace NetBook.Core.Entities
{
    public class User : BaseEntity
    {
        public User() { }
        
        public User(string firstName, string lastName, DateTime birthDate, string phoneNumber, string email, string password, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Role = role;

            Status = UserStatusEnum.Enabled;

            Publications = new Collection<Publication>();
            Comments = new Collection<Comment>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public virtual string Email { get; private set; }
        public virtual string Password { get; private set; }
        public string Role { get; private set; }



        public UserStatusEnum Status { get; private set; }
        public ICollection<Publication> Publications { get; private set; }
        public ICollection<Comment> Comments { get; private set; }




        public virtual void DisabledAccount()
        {
            Status = UserStatusEnum.Disabled;
        }

        public virtual void EnableAccount()
        {
            Status = UserStatusEnum.Enabled;
        }

        public void Update(string firstName, string lastName, DateTime birthDate, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
        }
    }
}
