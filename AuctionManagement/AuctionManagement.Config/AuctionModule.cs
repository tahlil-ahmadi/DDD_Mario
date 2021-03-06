﻿using System;
using AuctionManagement.Application;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Auctions;
using AuctionManagement.Persistence.NH;
using AuctionManagement.Persistence.NH.Mapping;
using AuctionManagement.Persistence.NH.Repositories;
using Autofac;
using Framework.Application;
using Framework.Core;
using Framework.Logging.SLog;
using Framework.NH;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace AuctionManagement.Config
{
    public class AuctionModule : Module
    {
        private readonly AuctionConfig _config;
        public AuctionModule(AuctionConfig config)
        {
            _config = config;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var factory = SessionFactoryConfigurator.Create(typeof(AuctionMapping).Assembly, _config.ConnectionString);
            builder.Register(a => factory.OpenSession()).OwnedByLifetimeScope();
            builder.RegisterType<AuctionRepository>().As<IAuctionRepository>().OwnedByLifetimeScope();
            builder.RegisterType<AuctionHandlers>().As<ICommandHandler<OpenAuctionCommand>>().OwnedByLifetimeScope();
            builder.RegisterType<AuctionHandlers>().As<ICommandHandler<PlaceBidCommand>>().OwnedByLifetimeScope();
        }
    }
}
