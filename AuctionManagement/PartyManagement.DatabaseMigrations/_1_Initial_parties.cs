using System;
using FluentMigrator;

namespace PartyManagement.DatabaseMigrations
{
    [Migration(1)]
    public class _1_Initial_parties : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Parties")
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("State").AsByte().NotNullable();

            Create.Table("IndividualParties")
                .WithColumn("Id").AsInt64().PrimaryKey().ForeignKey("Parties", "Id")
                .WithColumn("Firstname").AsString(255).NotNullable()
                .WithColumn("Lastname").AsString(255).NotNullable();

            Create.Table("Phones")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("PartyId").AsInt64().ForeignKey("Parties", "Id")
                .WithColumn("AreaCode").AsString(5).NotNullable()
                .WithColumn("Number").AsString(20).NotNullable();

        }

    }
}
