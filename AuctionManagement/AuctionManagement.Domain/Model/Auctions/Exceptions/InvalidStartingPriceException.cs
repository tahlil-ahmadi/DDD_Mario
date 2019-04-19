using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Core;
using Framework.Core;

namespace AuctionManagement.Domain.Model.Auctions.Exceptions
{
    public class InvalidStartingPriceException : BusinessException
    {
        public InvalidStartingPriceException() 
            : base(ExceptionCodes.InvalidStartingPrice, ExceptionMessages.InvalidStartingPrice)
        {
        }
    }
}
