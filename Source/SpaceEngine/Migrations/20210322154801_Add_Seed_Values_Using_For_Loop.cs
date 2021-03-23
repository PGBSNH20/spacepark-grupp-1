using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceEngine.Migrations
{
    public partial class Add_Seed_Values_Using_For_Loop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parkingspots",
                columns: new[] { "ID", "CharacterName", "MaxSize", "MinSize", "SpaceshipName" },
                values: new object[,]
                {
                    { 2, null, 500, 0, null },
                    { 3, null, 500, 0, null },
                    { 4, null, 500, 0, null },
                    { 5, null, 500, 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkingspots",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parkingspots",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parkingspots",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parkingspots",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
