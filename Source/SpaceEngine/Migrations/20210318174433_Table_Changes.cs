using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaceEngine.Migrations
{
    public partial class Table_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropPrimaryKey(
                name: "PK_starShip",
                table: "starShip");

            migrationBuilder.RenameTable(
                name: "starShip",
                newName: "StarShip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StarShip",
                table: "StarShip");

            migrationBuilder.RenameTable(
                name: "StarShip",
                newName: "starShip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_starShip",
                table: "starShip",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.ID);
                });
        }
    }
}
