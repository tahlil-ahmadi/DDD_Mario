using Framework.Core;
using System;

namespace AuctionManagement.Domain.Contracts
{
    public class BidPlaced : DomainEvent
    {
        public long AuctionId { get; private set; }
        public long BidderId { get; private set; }
        public long BidAmount { get; private set; }
        public DateTime PlaceDateTime { get; private set; }
        public BidPlaced(long auctionId, long bidderId, long bidAmount, DateTime placeDateTime)
        {
            AuctionId = auctionId;
            BidderId = bidderId;
            BidAmount = bidAmount;
            PlaceDateTime = placeDateTime;
        }
    }
}
