using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using NServiceBus;

namespace AuctionManagement.Application.NSB
{
    public class AuctionEventHandler : IHandleMessages<BidPlaced>
    {
        public Task Handle(BidPlaced message, IMessageHandlerContext context)
        {
            //TODO: dispatch a command to create a 'bidHistory' aggregate 
            return Task.CompletedTask;
        }
    }
}
