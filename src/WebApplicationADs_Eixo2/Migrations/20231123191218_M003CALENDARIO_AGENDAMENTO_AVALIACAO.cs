using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M003CALENDARIO_AGENDAMENTO_AVALIACAO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Usuarios_IdUser",
                table: "Calendario");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_IdUser",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "DiaSemana",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Calendario");

            migrationBuilder.RenameColumn(
                name: "Mes",
                table: "Calendario",
                newName: "IdUsuario");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraInicio",
                table: "Calendario",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraFim",
                table: "Calendario",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtAlteracao",
                table: "Calendario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DtFimEvento",
                table: "Calendario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInicioEvento",
                table: "Calendario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PedindoAjuda",
                table: "Calendario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCalendario = table.Column<int>(type: "int", nullable: false),
                    IdColaborador = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendamento_Calendario_IdCalendario",
                        column: x => x.IdCalendario,
                        principalTable: "Calendario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendamento_Usuarios_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdAgendamento = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DtInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Agendamento_IdAgendamento",
                        column: x => x.IdAgendamento,
                        principalTable: "Agendamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Avaliacao_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_IdUsuario",
                table: "Calendario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdCalendario",
                table: "Agendamento",
                column: "IdCalendario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdColaborador",
                table: "Agendamento",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdAgendamento",
                table: "Avaliacao",
                column: "IdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdUsuario",
                table: "Avaliacao",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Usuarios_IdUsuario",
                table: "Calendario",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Usuarios_IdUsuario",
                table: "Calendario");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_IdUsuario",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "DtFimEvento",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "DtInicioEvento",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "PedindoAjuda",
                table: "Calendario");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Calendario",
                newName: "Mes");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraInicio",
                table: "Calendario",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HoraFim",
                table: "Calendario",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtAlteracao",
                table: "Calendario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Calendario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dia",
                table: "Calendario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiaSemana",
                table: "Calendario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Calendario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_IdUser",
                table: "Calendario",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Usuarios_IdUser",
                table: "Calendario",
                column: "IdUser",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
