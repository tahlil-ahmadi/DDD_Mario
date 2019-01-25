using System;
using AuctionManagement.Application;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Persistence.NH;
using AuctionManagement.Persistence.NH.Mapping;
using AuctionManagement.Persistence.NH.Repositories;
using Framework.Application;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace AuctionManagement.Config
{
    public static class AuctionConfig
    {
        public static void AddAuction(this IServiceCollection collection)
        {
            //TODO: remove connection string from here
            var connectionString = @"Data source=CLASS1\MSSQLSERVER1;Initial Catalog=Auction_DB;User Id=sa;password=123";
            var factory = SessionFactoryConfigurator.Create(typeof(AuctionMapping).Assembly,connectionString);
            collection.AddScoped<ISession>(a=> factory.OpenSession());

            collection.AddScoped<IAuctionRepository, AuctionRepository>();
            collection.AddScoped<ICommandHandler<OpenAuctionCommand>, AuctionService>();
            collection.AddScoped<ICommandHandler<PlaceBidCommand>, AuctionService>();

            //TODO: refactor this class (replace autofac)
            var bus = new IocCommandBus(collection.BuildServiceProvider());
            collection.AddSingleton<ICommandBus>(a => bus);
        }
    }
}
