using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROJETO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATEGORIA = table.Column<int>(type: "int", nullable: false),
                    DATAINICIO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAENTREGA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROJETO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoUsuario",
                columns: table => new
                {
                    ProjetosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuariosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoUsuario", x => new { x.ProjetosId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_ProjetoUsuario_PROJETO_ProjetosId",
                        column: x => x.ProjetosId,
                        principalTable: "PROJETO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoUsuario_USUARIO_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoUsuario_UsuariosId",
                table: "ProjetoUsuario",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_email",
                table: "USUARIO",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoUsuario");

            migrationBuilder.DropTable(
                name: "PROJETO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
