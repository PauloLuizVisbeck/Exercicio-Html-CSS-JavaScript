using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AulaEntity.Migrations
{
    public partial class compromisso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compromisso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    ContatoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compromisso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compromisso_Contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compromisso_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compromisso_ContatoId",
                table: "Compromisso",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compromisso_LocalId",
                table: "Compromisso",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compromisso");
        }
    }
}
