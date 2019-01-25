using System;
using System.Collections.Generic;
using System.Text;
using Framework.Application;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionManagement.Config
{
    //TODO: refactor this and move to it's own place (replace with autofac)
    public class IocCommandBus : ICommandBus
    {
        private readonly IServiceProvider _serviceProvider;
        public IocCommandBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Dispatch<T>(T command)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = (ICommandHandler<T>)scope.ServiceProvider.GetService(typeof(ICommandHandler<T>));
                handler.Handle(command);
            }
        }
    }
}
