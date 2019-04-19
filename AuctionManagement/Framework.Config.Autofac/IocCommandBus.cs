using Autofac;
using Framework.Application;

namespace Framework.Config.Autofac
{
    public class AutofacCommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;
        public AutofacCommandBus(ILifetimeScope lifetimeScope)
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
