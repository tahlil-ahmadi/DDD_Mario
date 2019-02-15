using System;
using System.Collections.Generic;
using PartyManagement.Domain.Model;
using PartyManagement.Domain.Model.Parties;
using PartyManagement.Persistence.NH.Mappings;
using Xunit;

namespace PartyManagement.Persistence.NH.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var connectionString = @"Data source=CLASS1\MSSQLSERVER1;Initial Catalog=Auction_DB;User Id=sa;password=123";
            var factory = SessionFactoryConfigurator.Create(typeof(PartyMapping).Assembly, connectionString);
            var session = factory.OpenSession();

            session.BeginTransaction();
            var party = session.Get<IndividualParty>(2L);
            party.Confirm();
            session.Transaction.Commit();
        }
    }
}
