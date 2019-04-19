using System.Collections.Generic;
using AuctionManagement.Query.Model;

namespace AuctionManagement.Query.Services
{
    public interface IAuctionQueryService
    {
        List<Auction> Get(long page, long pageSize);
        Auction GetById(long id);
    }
}