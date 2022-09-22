using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImpactaWebcrawler.Migrations
{
    public partial class criandoBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "resposta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    horaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paginas = table.Column<int>(type: "int", nullable: false),
                    linhas = table.Column<int>(type: "int", nullable: false),
                    horaFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resposta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resposta");
        }
    }
}
