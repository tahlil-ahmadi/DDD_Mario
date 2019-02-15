namespace PartyManagement.Domain.Model.Parties
{
    public class LegalParty : Party
    {
        public string RegistrationCode { get; private set; }
        public LegalParty(string registrationCode)
        {
            RegistrationCode = registrationCode;
        }
    }
}