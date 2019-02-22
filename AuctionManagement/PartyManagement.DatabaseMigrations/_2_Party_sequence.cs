using System;
using FluentMigrator;

namespace PartyManagement.DatabaseMigrations
{
    [Migration(2)]
    public class _2_Party_sequence : Migration
    {
        public override void Up()
        {
            Create.Sequence("PartySeq").Cache(50).IncrementBy(1).StartWith(1).MinValue(1);
        }

        public override void Down()
        {
            Delete.Sequence("PartySeq");
        }
    }
}
