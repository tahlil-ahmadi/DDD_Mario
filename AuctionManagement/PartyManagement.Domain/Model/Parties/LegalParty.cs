namespace PartyManagement.Domain.Model.Parties
{
    public class LegalParty : Party
    {
        private string _name;
        public string RegistrationCode { get; private set; }
        public override string Name => _name;
        public LegalParty(string registrationCode, string name)
        {
            this.RegistrationCode = registrationCode;
            this._name = name;
        }

    }
}