using Framework.Core;
using Framework.Domain;

namespace PartyManagement.Domain.Model
{
    public class Phone : ValueObject
    {
        public string AreaCode { get; private set; }
        public string Number { get; private set; }
        protected Phone() { }
        public Phone(string areaCode, string number)
        {
            AreaCode = areaCode;
            Number = number;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Phone) obj);
        }
        protected bool Equals(Phone other)
        {
            return new EqualsBuilder()
                .Append(this.AreaCode, other.AreaCode)
                .Append(this.Number, other.Number)
                .IsEquals();
        }
        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                .Append(this.AreaCode)
                .Append(this.Number)
                .ToHashCode();
        }
    }
}