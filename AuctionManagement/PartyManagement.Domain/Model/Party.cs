using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Framework.Domain;

namespace PartyManagement.Domain.Model
{
    public abstract class Party : Entity<long>
    {
        private IList<Phone> _phones;
        public IReadOnlyCollection<Phone> Phones => new ReadOnlyCollection<Phone>(this._phones);

        protected Party() { }
        protected Party(long id)
        {
            this.Id = id;
        }

        public void AssignPhones(List<Phone> phones)
        {
            this._phones = this._phones.Update(phones);
        }
    }
}
