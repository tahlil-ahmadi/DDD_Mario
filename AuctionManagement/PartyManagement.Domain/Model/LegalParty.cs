﻿namespace PartyManagement.Domain.Model
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