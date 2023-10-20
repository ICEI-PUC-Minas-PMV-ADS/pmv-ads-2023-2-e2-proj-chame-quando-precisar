using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M001BancoDeDados : Migration
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PerfilIdPerfilID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);                    
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfil_Perfil",
                        column: x => x.PerfilIdPerfilID,
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
                    UsuarioUsuario1Id = table.Column<int>(type: "int", nullable: false),
                    UsuarioUsuario2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => new { x.Usuario1, x.Usuario2 });
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_UsuarioUsuario1Id",
                        column: x => x.UsuarioUsuario1Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_UsuarioUsuario2Id",
                        column: x => x.UsuarioUsuario2Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioidUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calendario_Usuarios_UsuarioidUserId",
                        column: x => x.UsuarioidUserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DadosUsuarios",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SobreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNacimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDeficiencia = table.Column<int>(type: "int", nullable: false),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioIDUserId = table.Column<int>(type: "int", nullable: false),
                    DeficienciaIdDeficienciaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosUsuarios", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Deficiencia_DeficienciaIdDeficienciaID",
                        column: x => x.DeficienciaIdDeficienciaID,
                        principalTable: "Deficiencia",
                        principalColumn: "ID"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Usuarios_UsuarioIDUserId",
                        column: x => x.UsuarioIDUserId,
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
                    UsuarioRemetenteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioDestinatarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensPrivadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatarioId",
                        column: x => x.UsuarioDestinatarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetenteId",
                        column: x => x.UsuarioRemetenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioDestinatarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Usuarios_UsuarioDestinatarioId",
                        column: x => x.UsuarioDestinatarioId,
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
                    UsuarioDeficienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioColaboradorId = table.Column<int>(type: "int", nullable: false),
                    CalendarioIdCalendarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Calendario_CalendarioIdCalendarioID",
                        column: x => x.CalendarioIdCalendarioID,
                        principalTable: "Calendario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_UsuarioColaboradorId",
                        column: x => x.UsuarioColaboradorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_UsuarioDeficienteId",
                        column: x => x.UsuarioDeficienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
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
                    AgendamentoIdAgendamentoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAvaliadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoAgendamento", x => new { x.IdAgendamento, x.Avaliador });
                    table.ForeignKey(
                        name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoIdAgendamentoId",
                        column: x => x.AgendamentoIdAgendamentoId,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoAgendamento_Usuarios_UsuarioAvaliadorId",
                        column: x => x.UsuarioAvaliadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_CalendarioIdCalendarioID",
                table: "Agendamento",
                column: "CalendarioIdCalendarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioColaboradorId",
                table: "Agendamento",
                column: "UsuarioColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioDeficienteId",
                table: "Agendamento",
                column: "UsuarioDeficienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_UsuarioUsuario1Id",
                table: "Amigos",
                column: "UsuarioUsuario1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_UsuarioUsuario2Id",
                table: "Amigos",
                column: "UsuarioUsuario2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAgendamento_AgendamentoIdAgendamentoId",
                table: "AvaliacaoAgendamento",
                column: "AgendamentoIdAgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAgendamento_UsuarioAvaliadorId",
                table: "AvaliacaoAgendamento",
                column: "UsuarioAvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_UsuarioidUserId",
                table: "Calendario",
                column: "UsuarioidUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_DeficienciaIdDeficienciaID",
                table: "DadosUsuarios",
                column: "DeficienciaIdDeficienciaID");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_UsuarioIDUserId",
                table: "DadosUsuarios",
                column: "UsuarioIDUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensPrivadas_UsuarioDestinatarioId",
                table: "MensagensPrivadas",
                column: "UsuarioDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensPrivadas_UsuarioRemetenteId",
                table: "MensagensPrivadas",
                column: "UsuarioRemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_UsuarioDestinatarioId",
                table: "Notificacoes",
                column: "UsuarioDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DeficienciaIdDeficienciaID",
                table: "Usuarios",
                column: "DeficienciaIdDeficienciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilIdPerfilID",
                table: "Usuarios",
                column: "PerfilIdPerfilID");
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
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Deficiencia");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
