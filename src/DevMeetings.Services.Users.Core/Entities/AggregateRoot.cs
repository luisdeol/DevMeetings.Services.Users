using System;
using System.Collections.Generic;
using DevMeetings.Services.Users.Core.Events;

namespace DevMeetings.Services.Users.Core.Entities
{
    public class AggregateRoot
    {
        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
        public Guid Id { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event) {
            _events.Add(@event);
        }
    }
}