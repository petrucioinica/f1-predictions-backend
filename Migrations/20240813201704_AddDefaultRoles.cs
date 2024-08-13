using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace f1_predictions.Migrations
{
    public partial class AddDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Admin" },
                    { Guid.NewGuid(), "GameMaster" },
                    { Guid.NewGuid(), "Player" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Name",
                keyValues: new object[] { "Admin", "GameMaster", "Player" });
        }
    }
}
