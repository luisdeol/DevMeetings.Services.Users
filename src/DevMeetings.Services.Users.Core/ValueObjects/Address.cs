using System;

namespace DevMeetings.Services.Users.Core.ValueObjects
{
    public class Address
    {
        public Address(string street, string number, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public string GetFullAddress()
            => $"{Street}, {Number}, {City}, {State}, {ZipCode}";
        
        public bool Equals(Address other)
        {
            return Street.Equals(other.Street, StringComparison.OrdinalIgnoreCase) &&
                Number.Equals(other.Number, StringComparison.OrdinalIgnoreCase) &&
                City.Equals(other.City, StringComparison.OrdinalIgnoreCase) &&
                State.Equals(other.State, StringComparison.OrdinalIgnoreCase) &&
                ZipCode.Equals(other.ZipCode, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is Address && Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, Number, City, State, ZipCode);
        }
    }
}