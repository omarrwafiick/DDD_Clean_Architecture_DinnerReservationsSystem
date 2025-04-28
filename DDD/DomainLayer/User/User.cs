using DomainLayer.Common.BaseClasses; 
using DomainLayer.User.ValueObjects;

namespace DomainLayer.User
{
    public sealed class User : Entity<UserId>
    {
        private User(UserId userId, string firstName, string lastName, string email, string password, DateTime createdAt, DateTime updatedAt) : base(userId)
        { 
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }


        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new User(UserId.Create(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
        }
    }
}
