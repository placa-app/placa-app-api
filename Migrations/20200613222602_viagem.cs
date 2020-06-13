using Microsoft.EntityFrameworkCore.Migrations;

namespace Placa.API.Migrations
{
    public partial class viagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "viagens",
                columns: table => new
                {
                    ViagemId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Local = table.Column<string>(nullable: true),
                    DataEvento = table.Column<string>(nullable: true),
                    Tema = table.Column<string>(nullable: true),
                    QtdPessoas = table.Column<int>(nullable: false),
                    Lote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_viagens", x => x.ViagemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropTable(
                name: "viagens");


        }
    }
}
