using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionManagement.Domain.Model.Auctions
{
    public interface IAuctionRepository
    {
        AuctionId GetNextId();
        void Add(Auction auction);
        Auction Get(long id);
    }
}
