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

        public long GetNextId()
        {
            return _session.CreateSQLQuery("SELECT NEXT VALUE FOR AuctionSeq").UniqueResult<long>();
        }

        public void Add(Auction auction)
        {
            //TODO: remove transaction from here
            _session.BeginTransaction();
            _session.Save(auction);
            _session.Transaction.Commit();
        }

        public Auction Get(long id)
        {
            return _session.Get<Auction>(id);
        }
    }
}
