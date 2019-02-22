using System;

namespace Framework.Core
{
    public class DomainEvent : IDomainEvent
    {
        public Guid EventId { get; }
        public DateTime EventPublishDateTime { get; }

        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();    
            this.EventPublishDateTime = DateTime.Now;
        }
    }
}