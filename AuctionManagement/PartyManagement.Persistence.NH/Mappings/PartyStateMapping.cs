﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using PartyManagement.Domain.Model.Parties.States;
using PartyManagement.Persistence.NH.Framework;

namespace PartyManagement.Persistence.NH.Mappings
{
    public class PartyStateMapping : ImmutableUserType<PartyState>
    {
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            //TODO: move to attribute
            var value = (byte)NHibernateUtil.Byte.NullSafeGet(rs, names[0], session);
            if (value == 1) return PartyStateFactory.Create<PendingState>();
            else if (value == 2) return PartyStateFactory.Create<ConfirmedState>();
            else if (value == 255) return PartyStateFactory.Create<RejectedState>();

            throw new NotImplementedException();
        }

        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            //TODO: move to attribute
            var partyState = (PartyState)value;

            var valueToSave = 1;
            if (partyState is ConfirmedState)
                valueToSave = 2;
            else if (partyState is RejectedState)
                valueToSave = 255;

            NHibernateUtil.String.NullSafeSet(cmd, valueToSave.ToString(), index, session);
        }

        public override SqlType[] SqlTypes => new[] { new SqlType(DbType.Byte) };
    }
}
