using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaçãodaEntidadePacotesTuristicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reservas",
                newName: "Datainicial");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "PacoteTuristico",
                newName: "PrecoDiaria");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "CidadeDestinos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "Datainicial",
                table: "Reservas",
                newName: "DataReserva");

            migrationBuilder.RenameColumn(
                name: "PrecoDiaria",
                table: "PacoteTuristico",
                newName: "Preco");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "CidadeDestinos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
