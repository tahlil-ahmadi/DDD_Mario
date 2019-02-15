using System;
using AuctionManagement.Application;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Persistence.NH;
using AuctionManagement.Persistence.NH.Mapping;
using AuctionManagement.Persistence.NH.Repositories;
using Autofac;
using Framework.Application;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace AuctionManagement.Config
{
    public class AuctionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //TODO: remove connection string from here
            var connectionString = @"Data source=CLASS1\MSSQLSERVER1;Initial Catalog=Auction_DB;User Id=sa;password=123";
            var factory = SessionFactoryConfigurator.Create(typeof(AuctionMapping).Assembly, connectionString);
            builder.Register<ISession>(a => factory.OpenSession()).OwnedByLifetimeScope();
            builder.RegisterType<AuctionRepository>().As<IAuctionRepository>().OwnedByLifetimeScope();
            builder.RegisterType<AuctionService>().As<ICommandHandler<OpenAuctionCommand>>().OwnedByLifetimeScope();
            builder.RegisterType<AuctionService>().As<ICommandHandler<PlaceBidCommand>>().OwnedByLifetimeScope();
            builder.RegisterType<IocCommandBus>().As<ICommandBus>().SingleInstance();
        }
    }
}
