using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace Framework.Application
{
    public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T>
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public TransactionalCommandHandlerDecorator(ICommandHandler<T> commandHandler, 
            IUnitOfWork unitOfWork, ILogger logger)
        {
            _commandHandler = commandHandler;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void Handle(T command)
        {
            _unitOfWork.Begin();
            try
            {
                _commandHandler.Handle(command);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
