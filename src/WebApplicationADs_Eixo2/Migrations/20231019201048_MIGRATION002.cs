using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class MIGRATION002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Deficiencia_Deficiencia",
                table: "DadosUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfil_PerfilIdPerfilID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_DeficienciaIdDeficienciaID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PerfilIdPerfilID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DeficienciaIdDeficienciaID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PerfilIdPerfilID",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfil_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil",
                principalTable: "Perfil",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfil_IdPerfil",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "DeficienciaIdDeficienciaID",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerfilIdPerfilID",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DeficienciaIdDeficienciaID",
                table: "Usuarios",
                column: "DeficienciaIdDeficienciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilIdPerfilID",
                table: "Usuarios",
                column: "PerfilIdPerfilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Deficiencia_DeficienciaIdDeficienciaID",
                table: "Usuarios",
                column: "DeficienciaIdDeficienciaID",
                principalTable: "Deficiencia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfil_PerfilIdPerfilID",
                table: "Usuarios",
                column: "PerfilIdPerfilID",
                principalTable: "Perfil",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
