﻿using System;
using AuctionManagement.Application;
using AuctionManagement.Application.Contracts;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;

namespace AuctionManagement.Gateways.RestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public AuctionsController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public void Post(OpenAuctionCommand command)
        {
            command = new OpenAuctionCommand()
            {
                EndDateTime = DateTime.Now.AddDays(10),
                Product = "X",
                SellerId = 10,
                StartingPrice = 1000
            };
            _bus.Dispatch(command);
        }

        [HttpPost]
        [Route("{id}/Bids")]
        public void Post(PlaceBidCommand command)
        {
            _bus.Dispatch(command);
        }
    }
}
