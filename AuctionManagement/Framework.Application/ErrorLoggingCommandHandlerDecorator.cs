using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace Framework.Application
{
    public class ErrorLoggingCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _handler;
        private readonly ILogger _logger;

        public ErrorLoggingCommandHandlerDecorator(ICommandHandler<T> handler, ILogger logger)
        {
            _handler = handler;
            _logger = logger;
        }

        public void Handle(T command)
        {
            try
            {
                _handler.Handle(command);
            }
            catch (Exception e) when(!(e is BusinessException))
            {
                _logger.LogError(e);
                throw;
            }
        }
    }
}
