using System;
using System.Collections.Generic;
using System.Text;
using AuctionManagement.Application.Contracts;
using AuctionManagement.Domain.Model.Participant;
using Framework.Application;

namespace AuctionManagement.Application
{
    public class ParticipantHandlers : ICommandHandler<CreateParticipantCommand>
    {
        private readonly IParticipantRepository _repository;
        public ParticipantHandlers(IParticipantRepository repository)
        {
            _repository = repository;
        }
        public void Handle(CreateParticipantCommand command)
        {
            var participant = new Participant(command.Id, command.Name);
            _repository.Add(participant);
        }
    }
}
