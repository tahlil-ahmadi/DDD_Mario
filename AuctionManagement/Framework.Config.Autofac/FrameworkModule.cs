using System;
using Autofac;
using Framework.Application;
using Framework.Core;
using Framework.Logging.SLog;
using Framework.NH;

namespace Framework.Config.Autofac
{
    public class FrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(TransactionalCommandHandlerDecorator<>), typeof(ICommandHandler<>));
            builder.RegisterGenericDecorator(typeof(ErrorLoggingCommandHandlerDecorator<>), typeof(ICommandHandler<>));
            builder.RegisterType<AutofacCommandBus>().As<ICommandBus>().SingleInstance();
            builder.RegisterType<NhUnitOfWork>().As<IUnitOfWork>().OwnedByLifetimeScope();
            builder.Register(a => new SerilogAdapter(SerilogConfig.Config(@"Logs\Log.txt"))).As<ILogger>().SingleInstance();
        }
    }
}
