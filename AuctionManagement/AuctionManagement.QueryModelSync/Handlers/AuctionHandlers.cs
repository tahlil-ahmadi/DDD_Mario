using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuctionManagement.Domain.Contracts;
using NServiceBus;

namespace AuctionManagement.QueryModelSync.Handlers
{
    public class AuctionHandlers : IHandleMessages<AuctionOpened>,
                                   IHandleMessages<BidPlaced>
    {
        public Task Handle(AuctionOpened message, IMessageHandlerContext context)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BidPlaced message, IMessageHandlerContext context)
        {
            return Task.CompletedTask;
        }
    }

}
