namespace PartyManagement.Domain.Model.Parties.States
{
    public class PendingState : PartyState
    {
        public override PartyState GotoConfirmed()
        {
            return new ConfirmedState();
        }

        public override PartyState GotoRejected()
        {
            return new RejectedState();
        }
    }
}