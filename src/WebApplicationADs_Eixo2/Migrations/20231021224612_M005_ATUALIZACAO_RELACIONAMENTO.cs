using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M005_ATUALIZACAO_RELACIONAMENTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioIdCalendarioID",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioUsuario1Id",
                table: "Amigos");

            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioUsuario2Id",
                table: "Amigos");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoIdAgendamentoId",
                table: "AvaliacaoAgendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoAgendamento_Usuarios_UsuarioAvaliadorId",
                table: "AvaliacaoAgendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Usuarios_UsuarioidUserId",
                table: "Calendario");

            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuarios_Deficiencia_DeficienciaIdDeficienciaID",
                table: "DadosUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuarios_Usuarios_UsuarioIDUserId",
                table: "DadosUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Usuarios_UsuarioDestinatarioId",
                table: "Notificacoes");

            migrationBuilder.DropIndex(
                name: "IX_Notificacoes_UsuarioDestinatarioId",
                table: "Notificacoes");

            migrationBuilder.DropIndex(
                name: "IX_DadosUsuarios_DeficienciaIdDeficienciaID",
                table: "DadosUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_DadosUsuarios_UsuarioIDUserId",
                table: "DadosUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_UsuarioidUserId",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "UsuarioDestinatarioId",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "DeficienciaIdDeficienciaID",
                table: "DadosUsuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioIDUserId",
                table: "DadosUsuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioidUserId",
                table: "Calendario");

            migrationBuilder.RenameColumn(
                name: "UsuarioAvaliadorId",
                table: "AvaliacaoAgendamento",
                newName: "UserAvaliadorId");

            migrationBuilder.RenameColumn(
                name: "AgendamentoIdAgendamentoId",
                table: "AvaliacaoAgendamento",
                newName: "AgendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_AvaliacaoAgendamento_UsuarioAvaliadorId",
                table: "AvaliacaoAgendamento",
                newName: "IX_AvaliacaoAgendamento_UserAvaliadorId");

            migrationBuilder.RenameIndex(
                name: "IX_AvaliacaoAgendamento_AgendamentoIdAgendamentoId",
                table: "AvaliacaoAgendamento",
                newName: "IX_AvaliacaoAgendamento_AgendamentoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioUsuario2Id",
                table: "Amigos",
                newName: "User2Id");

            migrationBuilder.RenameColumn(
                name: "UsuarioUsuario1Id",
                table: "Amigos",
                newName: "User1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_UsuarioUsuario2Id",
                table: "Amigos",
                newName: "IX_Amigos_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_UsuarioUsuario1Id",
                table: "Amigos",
                newName: "IX_Amigos_User1Id");

            migrationBuilder.RenameColumn(
                name: "CalendarioIdCalendarioID",
                table: "Agendamento",
                newName: "CalendarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_CalendarioIdCalendarioID",
                table: "Agendamento",
                newName: "IX_Agendamento_CalendarioID");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DeficienciaID",
                table: "DadosUsuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_IdDestinatario",
                table: "Notificacoes",
                column: "IdDestinatario");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_DeficienciaID",
                table: "DadosUsuarios",
                column: "DeficienciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_IdUser",
                table: "Calendario",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioID",
                table: "Agendamento",
                column: "CalendarioID",
                principalTable: "Calendario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_User1Id",
                table: "Amigos",
                column: "User1Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_User2Id",
                table: "Amigos",
                column: "User2Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoId",
                table: "AvaliacaoAgendamento",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoAgendamento_Usuarios_UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                column: "UserAvaliadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Usuarios_IdUser",
                table: "Calendario",
                column: "IdUser",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuarios_Deficiencia_DeficienciaID",
                table: "DadosUsuarios",
                column: "DeficienciaID",
                principalTable: "Deficiencia",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Usuarios_IdDestinatario",
                table: "Notificacoes",
                column: "IdDestinatario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_DadosUsuarios_Id",
                table: "Usuarios",
                column: "Id",
                principalTable: "DadosUsuarios",
                principalColumn: "IDUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioID",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_User1Id",
                table: "Amigos");

            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_User2Id",
                table: "Amigos");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoId",
                table: "AvaliacaoAgendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoAgendamento_Usuarios_UserAvaliadorId",
                table: "AvaliacaoAgendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Usuarios_IdUser",
                table: "Calendario");

            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuarios_Deficiencia_DeficienciaID",
                table: "DadosUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Usuarios_IdDestinatario",
                table: "Notificacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DadosUsuarios_Id",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Notificacoes_IdDestinatario",
                table: "Notificacoes");

            migrationBuilder.DropIndex(
                name: "IX_DadosUsuarios_DeficienciaID",
                table: "DadosUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_IdUser",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "DeficienciaID",
                table: "DadosUsuarios");

            migrationBuilder.RenameColumn(
                name: "UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                newName: "UsuarioAvaliadorId");

            migrationBuilder.RenameColumn(
                name: "AgendamentoId",
                table: "AvaliacaoAgendamento",
                newName: "AgendamentoIdAgendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_AvaliacaoAgendamento_UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                newName: "IX_AvaliacaoAgendamento_UsuarioAvaliadorId");

            migrationBuilder.RenameIndex(
                name: "IX_AvaliacaoAgendamento_AgendamentoId",
                table: "AvaliacaoAgendamento",
                newName: "IX_AvaliacaoAgendamento_AgendamentoIdAgendamentoId");

            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "Amigos",
                newName: "UsuarioUsuario2Id");

            migrationBuilder.RenameColumn(
                name: "User1Id",
                table: "Amigos",
                newName: "UsuarioUsuario1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_User2Id",
                table: "Amigos",
                newName: "IX_Amigos_UsuarioUsuario2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_User1Id",
                table: "Amigos",
                newName: "IX_Amigos_UsuarioUsuario1Id");

            migrationBuilder.RenameColumn(
                name: "CalendarioID",
                table: "Agendamento",
                newName: "CalendarioIdCalendarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamento_CalendarioID",
                table: "Agendamento",
                newName: "IX_Agendamento_CalendarioIdCalendarioID");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioDestinatarioId",
                table: "Notificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeficienciaIdDeficienciaID",
                table: "DadosUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIDUserId",
                table: "DadosUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioidUserId",
                table: "Calendario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_UsuarioDestinatarioId",
                table: "Notificacoes",
                column: "UsuarioDestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_DeficienciaIdDeficienciaID",
                table: "DadosUsuarios",
                column: "DeficienciaIdDeficienciaID");

            migrationBuilder.CreateIndex(
                name: "IX_DadosUsuarios_UsuarioIDUserId",
                table: "DadosUsuarios",
                column: "UsuarioIDUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_UsuarioidUserId",
                table: "Calendario",
                column: "UsuarioidUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioIdCalendarioID",
                table: "Agendamento",
                column: "CalendarioIdCalendarioID",
                principalTable: "Calendario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioUsuario1Id",
                table: "Amigos",
                column: "UsuarioUsuario1Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioUsuario2Id",
                table: "Amigos",
                column: "UsuarioUsuario2Id",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoIdAgendamentoId",
                table: "AvaliacaoAgendamento",
                column: "AgendamentoIdAgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoAgendamento_Usuarios_UsuarioAvaliadorId",
                table: "AvaliacaoAgendamento",
                column: "UsuarioAvaliadorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Usuarios_UsuarioidUserId",
                table: "Calendario",
                column: "UsuarioidUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuarios_Deficiencia_DeficienciaIdDeficienciaID",
                table: "DadosUsuarios",
                column: "DeficienciaIdDeficienciaID",
                principalTable: "Deficiencia",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuarios_Usuarios_UsuarioIDUserId",
                table: "DadosUsuarios",
                column: "UsuarioIDUserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Usuarios_UsuarioDestinatarioId",
                table: "Notificacoes",
                column: "UsuarioDestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
