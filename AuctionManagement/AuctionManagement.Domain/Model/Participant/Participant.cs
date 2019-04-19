using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Participant
{
    public class Participant : AggregateRoot<long>
    {
        public string Name { get; set; }

        public Participant(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
