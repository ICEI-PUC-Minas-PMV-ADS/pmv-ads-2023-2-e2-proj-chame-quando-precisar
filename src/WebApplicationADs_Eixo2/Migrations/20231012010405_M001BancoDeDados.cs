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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);                    
                    table.ForeignKey(
                        name: "FK_Usuarios_Perfil_Perfil",
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
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => new { x.Usuario1, x.Usuario2 });
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_Usuario1",
                        column: x => x.Usuario1,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_Usuario2",
                        column: x => x.Usuario2,
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calendario_Usuarios_Usuario",
                        column: x => x.IdUser,
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
                        name: "FK_DadosUsuarios_Deficiencia_Deficiencia",
                        column: x => x.IdDeficiencia,
                        principalTable: "Deficiencia",
                        principalColumn: "ID"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_DadosUsuarios_Usuarios_Usuario",
                        column: x => x.IDUser,
                        principalTable: "Usuarios",
                        principalColumn: "Id"
                        /*onDelete: ReferentialAction.Cascade*/);
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
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensPrivadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatario",
                        column: x => x.IdDestinatario,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetente",
                        column: x => x.IdRemetente,
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Usuarios_UsuarioDestinatario",
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
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Calendario_Calendario",
                        column: x => x.IdCalendario,
                        principalTable: "Calendario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_UsuarioColaborador",
                        column: x => x.Colaborador,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_UsuarioDeficiente",
                        column: x => x.Deficiente,
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
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoAgendamento", x => new { x.IdAgendamento, x.Avaliador });
                    table.ForeignKey(
                        name: "FK_AvaliacaoAgendamento_Agendamento_Agendamento",
                        column: x => x.IdAgendamento,
                        principalTable: "Agendamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoAgendamento_Usuarios_UserAvaliador",
                        column: x => x.Avaliador,
                        principalTable: "Usuarios",
                        principalColumn: "Id"/*,
                        onDelete: ReferentialAction.Cascade*/);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_Calendario_Calendario",
                table: "Agendamento",
                column: "IdCalendario");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_Usuario_Colaborador",
                table: "Agendamento",
                column: "Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_Usuario_Deficiente",
                table: "Agendamento",
                column: "Deficiente");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_Usuario_Usuario1",
                table: "Amigos",
                column: "Usuario1");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_Usuario_Usuario2",
                table: "Amigos",
                column: "Usuario2");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAgendamento_Agendamento_Agendamento",
                table: "AvaliacaoAgendamento",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoAgendamento_Usuario_Avaliador",
                table: "AvaliacaoAgendamento",
                column: "Avaliador");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_Usuario_Usuario",
                table: "Calendario",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_Deficiencia_Deficiencia",
                table: "DadosUsuarios",
                column: "IdDeficiencia");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_Usuario_Usuario",
                table: "DadosUsuarios",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensPrivadas_Usuario_Destinatario",
                table: "MensagensPrivadas",
                column: "IdDestinatario");

            migrationBuilder.CreateIndex(
                name: "IX_MensagensPrivadas_Usuario_Remetente",
                table: "MensagensPrivadas",
                column: "IdRemetente");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_Usuario_Destinatario",
                table: "Notificacoes",
                column: "IdDestinatario");           

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Perfil_Perfil",
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
