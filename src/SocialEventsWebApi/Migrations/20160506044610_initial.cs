using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace SocialEventsWebApi.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "SocialEvent",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false),
                    Content = table.Column(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column(type: "datetime2", nullable: false),
                    EventDate = table.Column(type: "datetime2", nullable: false),
                    MapUrl = table.Column(type: "nvarchar(max)", nullable: true),
                    Title = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialEvent", x => x.Id);
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("SocialEvent");
        }
    }
}
