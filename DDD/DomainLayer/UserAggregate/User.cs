using DomainLayer.Common.BaseClasses; 
using DomainLayer.UserAggregate.ValueObjects;

namespace DomainLayer.UserAggregate
{
    public sealed class User : Entity<UserId>
    {
        public User() { }
        private User(UserId userId, string firstName, string lastName, string email, string password, DateTime createdAt, DateTime updatedAt) : base(userId)
        { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        public string Email { get; private set;}
        public string Password { get; private set;}
        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}


        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new User(UserId.Create(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
