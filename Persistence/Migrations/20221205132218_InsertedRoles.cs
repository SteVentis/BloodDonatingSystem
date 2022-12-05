using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "533344b6-7d43-4949-938c-b057c910b2a9", "12fd772c-bcfd-476c-a711-3d8912f3d22b", "Hospital", "Hospital" },
                    { "fb12c33b-39f4-4e17-bc98-3bd374585709", "ce2e4e9c-60ba-41dd-99bc-608afd1dad4a", "BloodDonationCenter", "BLOODDONATIONCENTER" },
                    { "51c41364-7781-434e-98a9-898514872d7a", "c268d224-8cb2-4850-a780-a731ab95a431", "BloodDonor", "BLOODDONOR" },
                    { "12ba589c-d048-4aa4-a268-bdf70f394fdb", "09c58af3-fe9b-4b6c-97b5-369f77201ef4", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12ba589c-d048-4aa4-a268-bdf70f394fdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51c41364-7781-434e-98a9-898514872d7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "533344b6-7d43-4949-938c-b057c910b2a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb12c33b-39f4-4e17-bc98-3bd374585709");
        }
    }
}
