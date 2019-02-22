using System;
using FluentMigrator;

namespace PartyManagement.DatabaseMigrations
{
    [Migration(3)]
    public class _3_Domain_Events : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("DomainEvents")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("EventPublishDateTime").AsDateTime().NotNullable()
                .WithColumn("EventType").AsString(int.MaxValue).NotNullable()
                .WithColumn("Body").AsString(int.MaxValue).NotNullable()
                .WithColumn("IsSent").AsBoolean().NotNullable();
        }
    }
}
