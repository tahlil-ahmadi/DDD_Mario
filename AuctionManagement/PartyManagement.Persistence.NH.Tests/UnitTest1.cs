using System;
using System.Collections.Generic;
using PartyManagement.Domain.Model;
using PartyManagement.Persistence.NH.Mappings;
using Xunit;

namespace PartyManagement.Persistence.NH.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //TODO: remove connection string from here
            var connectionString = @"Data source=CLASS1\MSSQLSERVER1;Initial Catalog=Auction_DB;User Id=sa;password=123";
            var factory = SessionFactoryConfigurator.Create(typeof(PartyMapping).Assembly, connectionString);
            var session = factory.OpenSession();

            var phones = new List<Phone>()
            {
                new Phone("021", "9090"),
                new Phone("021", "10030"),
                new Phone("021", "8890"),
            };
            session.BeginTransaction();
            var party = session.Get<IndividualParty>(2L);
            party.AssignPhones(phones);

            session.Transaction.Commit();
        }
    }
}
