using System;
using System.Collections.Generic;
using System.Text;

namespace PartyManagement.Domain.Model.Parties.States
{
    public abstract class PartyState
    {
        public virtual PartyState GotoConfirmed()=> throw new Exception("Invalid state");
        public virtual PartyState GotoRejected() => throw new Exception("Invalid state");

    }
}
