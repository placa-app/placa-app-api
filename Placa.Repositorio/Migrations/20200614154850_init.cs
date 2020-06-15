using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Placa.Repositorio.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    faixa_etaria = table.Column<string>(nullable: true),
                    carga_horaria = table.Column<int>(nullable: false),
                    alocacao = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_atualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProblemasSaude",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemasSaude", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Viagens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    origem = table.Column<string>(nullable: true),
                    destino = table.Column<string>(nullable: true),
                    distancia = table.Column<string>(nullable: true),
                    horario_partida = table.Column<DateTime>(nullable: false),
                    horario_previsto = table.Column<DateTime>(nullable: false),
                    estado_viagem = table.Column<string>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_atualizacao = table.Column<DateTime>(nullable: true),
                    MotoristaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Viagens_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemasMotoristas",
                columns: table => new
                {
                    ProblemaSaudeId = table.Column<int>(nullable: false),
                    MotoristaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemasMotoristas", x => new { x.ProblemaSaudeId, x.MotoristaId });
                    table.ForeignKey(
                        name: "FK_ProblemasMotoristas_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProblemasMotoristas_ProblemasSaude_ProblemaSaudeId",
                        column: x => x.ProblemaSaudeId,
                        principalTable: "ProblemasSaude",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProblemasMotoristas_MotoristaId",
                table: "ProblemasMotoristas",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_MotoristaId",
                table: "Viagens",
                column: "MotoristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemasMotoristas");

            migrationBuilder.DropTable(
                name: "Viagens");

            migrationBuilder.DropTable(
                name: "ProblemasSaude");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
