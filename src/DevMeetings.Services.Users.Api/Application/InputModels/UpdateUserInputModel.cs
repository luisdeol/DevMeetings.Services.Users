using System;

namespace DevMeetings.Services.Users.Api.Application.InputModels
{
    public class UpdateUserInputModel
    {
        public Guid Id { get; set; }
        public string Profession { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}