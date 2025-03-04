using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace f1_predictions.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminAndGameMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("12f3cd07-40d9-4732-aaf4-b0b5a5314a44"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c64de3b-1d1b-464f-8a71-ee25949a689e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b04d0e07-9b26-4417-a57e-1ed63f0c3b54"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Admin" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "GameMaster" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Player" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "ProfilePicture", "RoleId", "Username" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "admin@f1goes.br", "JeCoQdUgi44raJLIxf5Hm0EGiJ/YKKPSsmoc0p11ktY=", null, new Guid("11111111-1111-1111-1111-111111111111"), "admin" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "gamemaster@f1goes.br", "JeCoQdUgi44raJLIxf5Hm0EGiJ/YKKPSsmoc0p11ktY=", null, new Guid("11111111-1111-1111-1111-111111111111"), "Game Master" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12f3cd07-40d9-4732-aaf4-b0b5a5314a44"), "Player" },
                    { new Guid("4c64de3b-1d1b-464f-8a71-ee25949a689e"), "Admin" },
                    { new Guid("b04d0e07-9b26-4417-a57e-1ed63f0c3b54"), "GameMaster" }
                });
        }
    }
}
