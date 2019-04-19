using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace AuctionManagement.Domain.Model.Auctions
{
    public class AuctionId : ValueObject
    {
        public long DbId { get; private set; }
        protected AuctionId(){}
        public AuctionId(long dbId)
        {
            if (dbId <= 0) throw new ArgumentOutOfRangeException(nameof(dbId));
            DbId = dbId;
        }
        protected bool Equals(AuctionId other)
        {
            return base.Equals(other) && DbId == other.DbId;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AuctionId) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ DbId.GetHashCode();
            }
        }
    }
}
