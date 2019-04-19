using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Contracts;
using AuctionManagement.Domain.Model.Auctions.Exceptions;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class Auction : AggregateRoot<AuctionId>
    {
        public string Product { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long StartingPrice { get; private set; }
        public long SellerId { get; private set; }
        public Bid WinningBid { get; private set; }
        protected Auction(){}   //just for orm :|
        public Auction(AuctionId id, string product, DateTime endDateTime, long startingPrice, long sellerId)
        {
            if (startingPrice <= 0) throw new InvalidStartingPriceException();
            if (endDateTime <= DateTime.Now) throw new InvalidEndDateException();

            Id = id;
            Product = product;
            EndDateTime = endDateTime;
            StartingPrice = startingPrice;
            SellerId = sellerId;

            this.Publish(new AuctionOpened(Product, EndDateTime, StartingPrice, SellerId));
        }
        public void PlaceBid(Bid bid)
        {
            if (AuctionIsClosed()) throw new Exception("Auction is closed");
            if (IsInvalidAmount(bid.Amount)) throw new Exception("Invalid Amount");
            if (IsInvalidBidder(bid.BidderId)) throw new Exception("Invalid Bidder");

            this.WinningBid = bid;
            this.Publish(new BidPlaced(this.Id.DbId, bid.BidderId, bid.Amount, bid.CreateDateTime));
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
