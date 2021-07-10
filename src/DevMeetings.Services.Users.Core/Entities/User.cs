using System;
using DevMeetings.Services.Users.Core.Events;

namespace DevMeetings.Services.Users.Core.Entities
{
    public class User : AggregateRoot
    {
        public User(Guid id, string fullName, string profession)
        {
            Id = id;
            FullName = fullName;
            Profession = profession;
        }

        public string FullName { get; private set; }
        public string Profession { get; private set; }

        public static User Create(string fullName, string profession)
        {
            var user = new User(Guid.NewGuid(), fullName, profession);

            user.AddEvent(new UserCreated(user.Id));

            return user;
        }
    }
}