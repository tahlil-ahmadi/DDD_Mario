using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Application.Contracts
{
    public class CreateParticipantCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
