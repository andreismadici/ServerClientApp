using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerMagazin.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    IdSS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.IdSS);
                });

            migrationBuilder.CreateTable(
                name: "SlabComanda",
                columns: table => new
                {
                    IdSC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lungime = table.Column<double>(nullable: false),
                    Latime = table.Column<double>(nullable: false),
                    Material = table.Column<string>(nullable: false),
                    IdSS = table.Column<int>(nullable: false),
                    IdC = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlabComanda", x => x.IdSC);
                });

            migrationBuilder.CreateTable(
                name: "SlabComandaMod",
                columns: table => new
                {
                    IdSC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lungime = table.Column<double>(nullable: false),
                    Latime = table.Column<double>(nullable: false),
                    Material = table.Column<string>(nullable: false),
                    IdSS = table.Column<int>(nullable: false),
                    Id1 = table.Column<int>(nullable: false),
                    Id2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlabComandaMod", x => x.IdSC);
                });

            migrationBuilder.CreateTable(
                name: "SlabStoc",
                columns: table => new
                {
                    IdSS = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<string>(nullable: false),
                    Lungime = table.Column<double>(nullable: false),
                    Latime = table.Column<double>(nullable: false),
                    Taken = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlabStoc", x => x.IdSS);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "SlabComanda");

            migrationBuilder.DropTable(
                name: "SlabComandaMod");

            migrationBuilder.DropTable(
                name: "SlabStoc");
        }
    }
}
