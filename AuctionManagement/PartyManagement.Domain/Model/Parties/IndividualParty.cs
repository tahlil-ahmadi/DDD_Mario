namespace PartyManagement.Domain.Model.Parties
{
    public class IndividualParty : Party
    {
        public string Firstname { get;private  set; }
        public string Lastname { get; private set; }
        protected IndividualParty(){}   //for orm :|
        public IndividualParty(long id, string firstname, string lastname) : base(id)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}