using Framework.Core;

namespace PartyManagement.Domain.Contracts.Events
{
    public class PartyConfirmed : DomainEvent
    {
        public long PartyId { get; private set; }
        public string Name { get; private set; }
        public PartyConfirmed(long partyId, string name)
        {
            this.PartyId = partyId;
            this.Name = name;
        }
    }
}
