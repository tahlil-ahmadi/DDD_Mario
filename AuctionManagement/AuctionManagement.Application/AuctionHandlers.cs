using System;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Auctions;
using Framework.Application;

namespace AuctionManagement.Application
{
    public class AuctionHandlers : ICommandHandler<PlaceBidCommand>,
                                  ICommandHandler<OpenAuctionCommand>
    {
        private readonly IAuctionRepository _repository;
        public AuctionHandlers(IAuctionRepository repository)
        {
            _repository = repository;
        }
        public void Handle(OpenAuctionCommand command)
        {
            var id = _repository.GetNextId();
            var auction = new Auction(id, command.Product, command.EndDateTime, command.StartingPrice, command.SellerId);
            _repository.Add(auction);
        }
        public void Handle(PlaceBidCommand command)
        {
            var auction = _repository.Get(command.AuctionId);
            var bid = new Bid(command.BidderId, command.Amount);
            auction.PlaceBid(bid);
            //...update auction
        }
    }
}
