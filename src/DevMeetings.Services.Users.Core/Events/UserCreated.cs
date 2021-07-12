using System;

namespace DevMeetings.Services.Users.Core.Events
{
    public class UserCreated : IDomainEvent
    {
        public UserCreated(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}