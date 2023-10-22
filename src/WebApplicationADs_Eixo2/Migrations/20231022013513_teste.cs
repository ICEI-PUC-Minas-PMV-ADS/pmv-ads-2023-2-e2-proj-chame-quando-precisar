using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioID",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioColaboradorId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioDeficienteId",
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
                name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatarioId",
                table: "MensagensPrivadas");

            migrationBuilder.DropForeignKey(
                name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetenteId",
                table: "MensagensPrivadas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_DadosUsuarios_Id",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_IdUser",
                table: "Calendario");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioRemetenteId",
                table: "MensagensPrivadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioDestinatarioId",
                table: "MensagensPrivadas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IDUser",
                table: "DadosUsuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Calendario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AgendamentoId",
                table: "AvaliacaoAgendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User2Id",
                table: "Amigos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "User1Id",
                table: "Amigos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioDeficienteId",
                table: "Agendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioColaboradorId",
                table: "Agendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CalendarioID",
                table: "Agendamento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_UsuarioId",
                table: "Calendario",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioID",
                table: "Agendamento",
                column: "CalendarioID",
                principalTable: "Calendario",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioColaboradorId",
                table: "Agendamento",
                column: "UsuarioColaboradorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioDeficienteId",
                table: "Agendamento",
                column: "UsuarioDeficienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_User1Id",
                table: "Amigos",
                column: "User1Id",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_User2Id",
                table: "Amigos",
                column: "User2Id",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoAgendamento_Agendamento_AgendamentoId",
                table: "AvaliacaoAgendamento",
                column: "AgendamentoId",
                principalTable: "Agendamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoAgendamento_Usuarios_UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                column: "UserAvaliadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Usuarios_UsuarioId",
                table: "Calendario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosUsuarios_Usuarios_IDUser",
                table: "DadosUsuarios",
                column: "IDUser",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatarioId",
                table: "MensagensPrivadas",
                column: "UsuarioDestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetenteId",
                table: "MensagensPrivadas",
                column: "UsuarioRemetenteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Calendario_CalendarioID",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioColaboradorId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioDeficienteId",
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
                name: "FK_Calendario_Usuarios_UsuarioId",
                table: "Calendario");

            migrationBuilder.DropForeignKey(
                name: "FK_DadosUsuarios_Usuarios_IDUser",
                table: "DadosUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatarioId",
                table: "MensagensPrivadas");

            migrationBuilder.DropForeignKey(
                name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetenteId",
                table: "MensagensPrivadas");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_UsuarioId",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Calendario");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioRemetenteId",
                table: "MensagensPrivadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioDestinatarioId",
                table: "MensagensPrivadas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IDUser",
                table: "DadosUsuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserAvaliadorId",
                table: "AvaliacaoAgendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgendamentoId",
                table: "AvaliacaoAgendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User2Id",
                table: "Amigos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User1Id",
                table: "Amigos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioDeficienteId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioColaboradorId",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CalendarioID",
                table: "Agendamento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_Agendamento_Usuarios_UsuarioColaboradorId",
                table: "Agendamento",
                column: "UsuarioColaboradorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuarios_UsuarioDeficienteId",
                table: "Agendamento",
                column: "UsuarioDeficienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
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
                name: "FK_MensagensPrivadas_Usuarios_UsuarioDestinatarioId",
                table: "MensagensPrivadas",
                column: "UsuarioDestinatarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MensagensPrivadas_Usuarios_UsuarioRemetenteId",
                table: "MensagensPrivadas",
                column: "UsuarioRemetenteId",
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
    }
}
