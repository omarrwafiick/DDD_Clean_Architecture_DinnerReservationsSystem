using DomainLayer.Common.BaseClasses; 
using DomainLayer.User.ValueObjects;

namespace DomainLayer.User
{
    public sealed class User : Entity<UserId>
    {
        private User(UserId userId, string firstName, string lastName, string email, string password) : base(userId)
        { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new User(UserId.Create(), firstName, lastName, email, password);
        }
    }
}
