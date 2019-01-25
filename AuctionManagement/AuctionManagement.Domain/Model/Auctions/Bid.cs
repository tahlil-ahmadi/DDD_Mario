using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Bid : ValueObject
    {
        public long BidderId { get; private set; }
        public long Amount { get; private set; }
        public DateTime CreateDateTime { get; private set; }
        protected Bid() { }
        public Bid(long bidderId, long amount)
        {
            BidderId = bidderId;
            Amount = amount;
            this.CreateDateTime = DateTime.Now;
        }
    }
}
