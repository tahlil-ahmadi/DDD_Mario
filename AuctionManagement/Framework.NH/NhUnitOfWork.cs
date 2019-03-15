using System;
using System.Data;
using Framework.Core;
using NHibernate;

namespace Framework.NH
{
    public class NhUnitOfWork : IUnitOfWork
    {
        private ISession _session;
        public NhUnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            _session.Transaction.Begin(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            _session.Transaction.Commit();
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
        }
    }
}
