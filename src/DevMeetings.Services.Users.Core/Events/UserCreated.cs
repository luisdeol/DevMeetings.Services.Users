using System;

namespace DevMeetings.Services.Users.Core.Events
{
    public class UserCreated : IDomainEvent
    {
        public UserCreated(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}