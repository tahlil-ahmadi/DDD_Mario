using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Core;
using Framework.Domain;
using NHibernate;
using NHibernate.Event;

namespace PartyManagement.Persistence.NH.Framework
{
    public class DomainEventListener : IPreUpdateEventListener
    {
        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            if (@event.Entity is IAggregateRoot aggregateRoot)
            {
                var changes = aggregateRoot.GetChanges();
                foreach (var domainEvent in changes)
                {
                    var command = SqlCommandFactory.FromEvent(domainEvent);
                    command.Connection = (@event.Session as ISession).Connection as SqlConnection;
                    @event.Session.Transaction.Enlist(command);
                    command.ExecuteNonQuery();
                }
            }
            return false;
        }

    }
}
