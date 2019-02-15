using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Framework.Application;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionManagement.Config
{
    public class IocCommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;
        public IocCommandBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public void Dispatch<T>(T command)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                var handler = scope.Resolve<ICommandHandler<T>>();
                handler.Handle(command);
            }
        }
    }
}
