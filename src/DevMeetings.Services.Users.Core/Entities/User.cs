using System;
using DevMeetings.Services.Users.Core.Events;
using DevMeetings.Services.Users.Core.ValueObjects;

namespace DevMeetings.Services.Users.Core.Entities
{
    public class User : AggregateRoot
    {
        public User(Guid id, string fullName, string profession, string email)
        {
            Id = id;
            FullName = fullName;
            Profession = profession;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Profession { get; private set; }
        public string Email { get; private set; }
        public Address Address { get; private set; }

        public static User Create(string fullName, string profession, string email)
        {
            var user = new User(Guid.NewGuid(), fullName, profession, email);

            user.AddEvent(new UserCreated(user.Id, user.FullName, user.Email));

            return user;
        }

        public void Update(string profession, Address address) {
            Profession = profession;
            Address = address;

            AddEvent(new UserUpdated(Id, Profession, Address));
        }
    }
}