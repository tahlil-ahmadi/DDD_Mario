using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Auction : Entity<long>
    {
        public string Product { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long StartingPrice { get; private set; }
        public long SellerId { get; private set; }
        public Bid WinningBid { get; private set; }
        protected Auction(){}   //just for orm :|
        public Auction(long id, string product, DateTime endDateTime, long startingPrice, long sellerId)
        {
            if (startingPrice <= 0) throw new Exception("Invalid starting Price");
            if (endDateTime <= DateTime.Now) throw new Exception("Invalid EndDateTime");

            Id = id;
            Product = product;
            EndDateTime = endDateTime;
            StartingPrice = startingPrice;
            SellerId = sellerId;
        }
        public void PlaceBid(Bid bid)
        {
            if (AuctionIsClosed()) throw  new Exception("Auction is closed");
            if (IsInvalidAmount(bid.Amount)) throw new Exception("Invalid Amount");
            if (IsInvalidBidder(bid.BidderId)) throw new Exception("Invalid Bidder");

            this.WinningBid = bid;
        }
        private bool AuctionIsClosed()
        {
            return this.EndDateTime < DateTime.Now;
        }

        private bool IsInvalidAmount(long bidAmount)
        {
            var maxAmount = GetCurrentMaxAmount();
            return maxAmount >= bidAmount;
        }
        private long GetCurrentMaxAmount()
        {
            if (FirstOffer())
                return this.StartingPrice;
            return this.WinningBid.Amount;
        }
        private bool FirstOffer()
        {
            return this.WinningBid == null;
        }

        private bool IsInvalidBidder(long bidderId)
        {
            return this.SellerId == bidderId;
        }
    }
}
