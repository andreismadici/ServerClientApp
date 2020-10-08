using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerMagazin.Migrations
{
    public partial class UpdateComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Comanda",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "Comanda");
        }
    }
}
