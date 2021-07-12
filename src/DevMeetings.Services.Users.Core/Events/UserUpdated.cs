using System;
using DevMeetings.Services.Users.Core.Entities;
using DevMeetings.Services.Users.Core.ValueObjects;

namespace DevMeetings.Services.Users.Core.Events
{
    public class UserUpdated : IDomainEvent
    {
        public UserUpdated(Guid id, string profession, Address address)
        {
            Id = id;
            Profession = profession;
            Street = address.Street;
            Number = address.Number;
            City = address.City;
            State = address.State;
            ZipCode = address.ZipCode;
        }

        public Guid Id { get; private set; }
        public string Profession { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
    }
}