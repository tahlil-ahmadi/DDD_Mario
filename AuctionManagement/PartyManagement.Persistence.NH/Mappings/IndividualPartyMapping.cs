using NHibernate.Mapping.ByCode.Conformist;
using PartyManagement.Domain.Model;
using PartyManagement.Domain.Model.Parties;

namespace PartyManagement.Persistence.NH.Mappings
{
    public class IndividualPartyMapping : JoinedSubclassMapping<IndividualParty>
    {
        public IndividualPartyMapping()
        {
            Lazy(false);
            Table("IndividualParties");
            Key(a=>a.Column("Id"));
            Property(a=>a.Firstname);
            Property(a=>a.Lastname);
        }
    }
}