using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Application
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private ICommandHandler<T> _commandHandler;
        public TransactionalCommandHandlerDecorator(ICommandHandler<T> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public void Handle(T command)
        {
            //Begin transaction
            _commandHandler.Handle(command);
            //Commit transaction
        }
    }
}
