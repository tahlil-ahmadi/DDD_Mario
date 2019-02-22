using System;

namespace AuctionManagement.Application.Contracts
{
    public class OpenAuctionCommand
    {
        public string Product { get;  set; }
        public DateTime EndDateTime { get;  set; }
        public long StartingPrice { get;  set; }
        public long SellerId { get;  set; }
    }
}
