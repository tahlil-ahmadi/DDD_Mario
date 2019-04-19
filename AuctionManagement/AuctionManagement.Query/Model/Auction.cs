using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Query.Model
{
    public class Auction
    {
        public string Product { get; set; }
        public DateTime EndDateTime { get;  set; }
        public long StartingPrice { get;  set; }
        public long SellerId { get;  set; }
        public Bid WinnerBid { get; set; }
        public List<Bid> BidHistory { get; set; }
    }
    public class Bid
    {
        public long BidderId { get; set; }
        public long BidderName { get; set; }
        public long Amount { get;  set; }
        public DateTime CreateDateTime { get;  set; }
    }

}
