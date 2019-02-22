using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace PartyManagement.Domain.Model.Parties.Events
{
    public class PartyConfirmed : DomainEvent
    {
        public long PartyId { get; private set; }
        public PartyConfirmed(long partyId)
        {
            PartyId = partyId;
        }
    }
}
