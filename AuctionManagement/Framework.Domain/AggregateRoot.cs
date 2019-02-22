using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace Framework.Domain
{
    public abstract class AggregateRoot<T> : Entity<T>, IAggregateRoot
    {
        private List<IDomainEvent> _changes;
        protected AggregateRoot()
        {
            this._changes= new List<IDomainEvent>();
        }
        public void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            this._changes.Add(@event);
        }
        public IReadOnlyList<IDomainEvent> GetChanges()
        {
            return _changes;
        }
        public void ClearChanges()
        {
            this._changes.Clear();
        }
    }
}
