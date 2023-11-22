using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M001USUARIODADOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deficiencia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deficiencia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    Deficiente = table.Column<bool>(type: "bit", nullable: false),
                    Colaborador = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SobreNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SobreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNacimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDeficiencia = table.Column<int>(type: "int", nullable: true),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeficienciaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Deficiencia_DeficienciaID",
                        column: x => x.DeficienciaID,
                        principalTable: "Deficiencia",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Deficiencia_IdDeficiencia",
                        column: x => x.IdDeficiencia,
                        principalTable: "Deficiencia",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_DeficienciaID",
                table: "DadosUsuarios",
                column: "DeficienciaID");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_IdDeficiencia",
                table: "DadosUsuarios",
                column: "IdDeficiencia");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosUsuarios");

            migrationBuilder.DropTable(
                name: "Deficiencia");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
