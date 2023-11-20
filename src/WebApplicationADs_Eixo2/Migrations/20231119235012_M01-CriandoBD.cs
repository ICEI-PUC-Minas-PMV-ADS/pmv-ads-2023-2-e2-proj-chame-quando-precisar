using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M01CriandoBD : Migration
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    Deficiente = table.Column<bool>(type: "bit", nullable: false),
                    Colaborador = table.Column<bool>(type: "bit", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Preferencias",
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
                    table.PrimaryKey("PK_Preferencias", x => x.ID);
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    Usuario1 = table.Column<int>(type: "int", nullable: false),
                    Usuario2 = table.Column<int>(type: "int", nullable: false),
                    DataAmizade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User1Id = table.Column<int>(type: "int", nullable: true),
                    User2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => new { x.Usuario1, x.Usuario2 });
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "time", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calendario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DadosUsuarios",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false),
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosUsuarios", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Deficiencia_IdDeficiencia",
                        column: x => x.IdDeficiencia,
                        principalTable: "Deficiencia",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Usuarios_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MensagensPrivadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRemetente = table.Column<int>(type: "int", nullable: false),
                    IdDestinatario = table.Column<int>(type: "int", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextoMensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioRemetenteId = table.Column<int>(type: "int", nullable: true),
                    UsuarioDestinatarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensPrivadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatarioId",
                        column: x => x.UsuarioDestinatarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetenteId",
                        column: x => x.UsuarioRemetenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDestinatario = table.Column<int>(type: "int", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextoMensagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lido = table.Column<bool>(type: "bit", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Usuarios_IdDestinatario",
                        column: x => x.IdDestinatario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deficiente = table.Column<int>(type: "int", nullable: false),
                    Colaborador = table.Column<int>(type: "int", nullable: false),
                    IdCalendario = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioDeficienteId = table.Column<int>(type: "int", nullable: true),
                    UsuarioColaboradorId = table.Column<int>(type: "int", nullable: true),
                    CalendarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Calendario_CalendarioID",
                        column: x => x.CalendarioID,
                        principalTable: "Calendario",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_UsuarioColaboradorId",
                        column: x => x.UsuarioColaboradorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_UsuarioDeficienteId",
                        column: x => x.UsuarioDeficienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoAgendamento",
                columns: table => new
                {
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    Avaliador = table.Column<int>(type: "int", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgendamentoId = table.Column<int>(type: "int", nullable: true),
                    UserAvaliadorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoAgendamento", x => new { x.IdAgendamento, x.Avaliador });
                    table.ForeignKey(
                        name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AvaliacaoAgendamento_Usuarios_UserAvaliadorId",
                        column: x => x.UserAvaliadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_CalendarioID",
                table: "Agendamento",
                column: "CalendarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioColaboradorId",
                table: "Agendamento",
                column: "UsuarioColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioDeficienteId",
                table: "Agendamento",
                column: "UsuarioDeficienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_User1Id",
                table: "Amigos",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_User2Id",
                table: "Amigos",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAgendamento_AgendamentoId",
                table: "AvaliacaoAgendamento",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAgendamento_UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                column: "UserAvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_UsuarioId",
                table: "Calendario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_IdDeficiencia",
                table: "DadosUsuarios",
                column: "IdDeficiencia");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensPrivadas_UsuarioDestinatarioId",
                table: "MensagensPrivadas",
                column: "UsuarioDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensPrivadas_UsuarioRemetenteId",
                table: "MensagensPrivadas",
                column: "UsuarioRemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_IdDestinatario",
                table: "Notificacoes",
                column: "IdDestinatario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPerfil",
                table: "Usuarios",
                column: "IdPerfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "AvaliacaoAgendamento");

            migrationBuilder.DropTable(
                name: "DadosUsuarios");

            migrationBuilder.DropTable(
                name: "MensagensPrivadas");

            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "Preferencias");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Deficiencia");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
