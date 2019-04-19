using System;
using System.Threading.Tasks;
using AuctionManagement.Application.Contracts;
using Framework.Application;
using NServiceBus;
using PartyManagement.Domain.Contracts.Events;

namespace AuctionManagement.Application.NSB
{
    public class PartyEventHandler : IHandleMessages<PartyConfirmed>
    {
        private readonly ICommandBus _commandBus;
        public PartyEventHandler(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }
        public Task Handle(PartyConfirmed message, IMessageHandlerContext context)
        {
            var command = new CreateParticipantCommand
            {
                Id = message.PartyId,
                Name = message.Name
            };
            _commandBus.Dispatch(command);
            return Task.CompletedTask;
        }
    }
}
