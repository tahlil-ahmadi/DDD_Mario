using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Domain;
using NHibernate.Event;

namespace PartyManagement.Persistence.NH.Framework
{
    public class DomainEventListener : IPreUpdateEventListener,
                   IPreInsertEventListener
    {
        public async Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            if (@event.Entity is IAggregateRoot aggregateRoot)
            {
                var changes = aggregateRoot.GetChanges();
                //save changes in database
                return false;
            }
            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
