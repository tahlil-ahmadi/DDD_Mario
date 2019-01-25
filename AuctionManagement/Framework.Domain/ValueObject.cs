using System;
using System.Collections.Generic;
using System.Text;
using Framework.Core;

namespace Framework.Domain
{
    public abstract class ValueObject
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            return EqualsBuilder.ReflectionEquals(this, obj);
        }

        public override int GetHashCode()
        {
            return HashCodeBuilder.ReflectionHashCode(this);
        }
    }
}
