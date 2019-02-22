using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Framework.Core;
using Newtonsoft.Json;

namespace PartyManagement.Persistence.NH.Framework
{
    public static class SqlCommandFactory 
    {
        public static SqlCommand FromEvent(IDomainEvent @event)
        {
            var text =
                "INSERT INTO DomainEvents(Id, EventPublishDateTime, EventType, Body, IsSent) " +
                "VALUES(@Id, @EventPublishDateTime, @EventType, @Body, @IsSent)";

            var serializedBody = JsonConvert.SerializeObject(@event);

            var command = new SqlCommand(text);
            command.Parameters.AddWithValue("@Id", @event.EventId);
            command.Parameters.AddWithValue("@EventPublishDateTime", @event.EventPublishDateTime);
            command.Parameters.AddWithValue("@EventType", @event.GetType().AssemblyQualifiedName);
            command.Parameters.AddWithValue("@Body", serializedBody);
            command.Parameters.AddWithValue("@IsSent", false);
            return command;
        }
    }
}
