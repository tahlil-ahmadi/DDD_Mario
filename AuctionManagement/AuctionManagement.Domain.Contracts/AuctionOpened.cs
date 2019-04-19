using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace AuctionManagement.Domain.Contracts
{
    public class AuctionOpened : DomainEvent
    {
        public string Product { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long StartingPrice { get; private set; }
        public long SellerId { get; private set; }
        public AuctionOpened(string product, DateTime endDateTime, long startingPrice, long sellerId)
        {
            Product = product;
            EndDateTime = endDateTime;
            StartingPrice = startingPrice;
            SellerId = sellerId;
        }
    }
}
