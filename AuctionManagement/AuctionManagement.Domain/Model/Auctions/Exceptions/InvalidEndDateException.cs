using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Core;
using Framework.Core;

namespace AuctionManagement.Domain.Model.Auctions.Exceptions
{
    public class InvalidEndDateException : BusinessException
    {
        public InvalidEndDateException() 
            : base(ExceptionCodes.InvalidEndDate, ExceptionMessages.InvalidEndDate)
        {
        }
    }
}
