using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerMagazin.Migrations
{
    public partial class ThreeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comanda",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "IdSS",
                table: "Comanda");

            migrationBuilder.AddColumn<int>(
                name: "IdC",
                table: "Comanda",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comanda",
                table: "Comanda",
                column: "IdC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comanda",
                table: "Comanda");

            migrationBuilder.DropColumn(
                name: "IdC",
                table: "Comanda");

            migrationBuilder.AddColumn<int>(
                name: "IdSS",
                table: "Comanda",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comanda",
                table: "Comanda",
                column: "IdSS");
        }
    }
}
