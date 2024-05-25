using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "USUARIO",
                newName: "EMAIL");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIO_email",
                table: "USUARIO",
                newName: "IX_USUARIO_EMAIL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "USUARIO",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                newName: "IX_USUARIO_email");
        }
    }
}
