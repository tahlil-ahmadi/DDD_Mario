using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace AuctionManagement.Persistence.NH.Mapping
{
    public class AuctionMapping : ClassMapping<Auction>
    {
        public AuctionMapping()
        {
            Lazy(false);
            Table("Auctions");
            Id(a=>a.Id);
            Property(a=>a.Product);
            Property(a=>a.EndDateTime);
            Property(a=>a.SellerId);
            Property(a=>a.StartingPrice);
            Component(a=>a.WinningBid, mapper =>
            {
                mapper.Property(a=>a.BidderId, a=>a.Column("WinningBid_BidderId"));
                mapper.Property(a=>a.Amount, a=>a.Column("WinningBid_Amount"));
                mapper.Property(a=>a.CreateDateTime, a=>a.Column("WinningBid_CreateDateTime"));
            });
        }
    }
}
