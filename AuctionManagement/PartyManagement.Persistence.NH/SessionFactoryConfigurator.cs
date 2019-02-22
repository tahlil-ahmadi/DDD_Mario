using System.Data;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Event;
using NHibernate.Mapping.ByCode;
using PartyManagement.Persistence.NH.Framework;

namespace PartyManagement.Persistence.NH
{
    public static class SessionFactoryConfigurator
    {
        public static ISessionFactory Create(Assembly mappingAssembly, string connectionString)
        {
            var configuration = new Configuration();
            configuration.SessionFactoryName("AuctionManagement");
            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = connectionString;
                db.Timeout = 30;
            });

            configuration.AddAssembly(mappingAssembly);
            var modelMapper = new ModelMapper();
            modelMapper.BeforeMapClass += (mi, t, map) => map.DynamicUpdate(true);
            modelMapper.AddMappings(mappingAssembly.GetExportedTypes());
            var mappingDocument = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddDeserializedMapping(mappingDocument, "AuctionManagement");

            AddDomainEventListeners(configuration);

            return configuration.BuildSessionFactory();
        }

        private static void AddDomainEventListeners(Configuration configuration)
        {
            var listener = new DomainEventListener();
            configuration.SetListeners(ListenerType.PreUpdate, new [] {listener});
        }
    }

  
}
