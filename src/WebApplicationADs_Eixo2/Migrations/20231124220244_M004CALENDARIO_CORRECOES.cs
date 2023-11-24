using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationADs_Eixo2.Migrations
{
    /// <inheritdoc />
    public partial class M004CALENDARIO_CORRECOES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Calendario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Calendario");
        }
    }
}
