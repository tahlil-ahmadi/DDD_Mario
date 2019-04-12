using System.Collections.Generic;
using System.Collections.ObjectModel;
using Framework.Domain;
using PartyManagement.Domain.Contracts.Events;
using PartyManagement.Domain.Model.Parties.States;

namespace PartyManagement.Domain.Model.Parties
{
    public abstract class Party : AggregateRoot<long>
    {
        private IList<Phone> _phones;
        public IReadOnlyCollection<Phone> Phones => new ReadOnlyCollection<Phone>(this._phones);
        public PartyState State { get; private set; }

        protected Party() { }
        protected Party(long id)
        {
            this.Id = id;
            this.State = PartyStateFactory.Create<PendingState>();
        }

        public void AssignPhones(List<Phone> phones)
        {
            this._phones = this._phones.Update(phones);
        }
        public void Confirm()
        {
            this.State = this.State.GotoConfirmed();
            Publish(new PartyConfirmed(this.Id));
        }
        public void Reject()
        {
            this.State = this.State.GotoRejected();
        }
    }
}
