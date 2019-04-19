using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionManagement.Domain.Model.Participant
{
    public interface IParticipantRepository
    {
        Participant GetById(long id);
        void Add(Participant participant);
    }
}
