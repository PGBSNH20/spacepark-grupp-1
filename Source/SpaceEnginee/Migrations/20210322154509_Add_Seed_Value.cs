using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceEngine.Migrations
{
    public partial class Add_Seed_Value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parkingspots",
                columns: new[] { "ID", "CharacterName", "MaxSize", "MinSize", "SpaceshipName" },
                values: new object[] { 1, null, 500, 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkingspots",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
