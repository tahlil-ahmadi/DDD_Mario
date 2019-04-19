using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Domain.Model.Auctions;
using NHibernate;

namespace AuctionManagement.Persistence.NH.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ISession _session;
        public AuctionRepository(ISession session)
        {
            this._session = session;
        }

        public AuctionId GetNextId()
        {
            return new AuctionId(_session.CreateSQLQuery("SELECT NEXT VALUE FOR AuctionSeq").UniqueResult<long>());
        }

        public void Add(Auction auction)
        {
            _session.Save(auction);
        }

        public Auction Get(long id)
        {
            return _session.Get<Auction>(id);
        }
    }
}
