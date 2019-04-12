namespace PartyManagement.Domain.Model.Parties.States
{
    public class PendingState : PartyState
    {
        public override PartyState GotoConfirmed()
        {
            return PartyStateFactory.Create<ConfirmedState>();
        }

        public override PartyState GotoRejected()
        {
            return PartyStateFactory.Create<RejectedState>();
        }
    }
}