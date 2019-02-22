using System.Collections.Generic;
using Framework.Core;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
        IReadOnlyList<IDomainEvent> GetChanges();
        void ClearChanges();
    }
}