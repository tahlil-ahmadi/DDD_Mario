using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PartyManagement.Domain.Model;
using PartyManagement.Domain.Model.Parties;

namespace PartyManagement.Persistence.NH.Mappings
{
    public class PartyMapping : ClassMapping<Party>
    {
        public PartyMapping()
        {
            Lazy(false);
            Table("Parties");
            Id(a=>a.Id);
            Property(a=>a.State, z=>z.Type<PartyStateMapping>());
            IdBag(a=>a.Phones, mapper =>
            {
                mapper.Table("Phones");
                mapper.Key(a => a.Column("PartyId"));
                mapper.Cascade(Cascade.All);
                mapper.Access(Accessor.Field);
                mapper.Id(a =>
                {
                    a.Column("Id");
                    a.Generator(Generators.Identity);
                });
            }, relation => relation.Component(map =>
            {
                map.Property(a=>a.AreaCode, a=>a.Column("AreaCode"));
                map.Property(a=>a.Number, a=>a.Column("Number"));
            }));
        }
    }
}
