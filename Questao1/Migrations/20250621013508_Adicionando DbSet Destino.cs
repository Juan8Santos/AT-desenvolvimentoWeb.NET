using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AT.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoDbSetDestino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CidadeDestinos_PaisDestino_PaisDestinoId",
                table: "CidadeDestinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Destino_CidadeDestinos_CidadeDestinoId",
                table: "Destino");

            migrationBuilder.DropForeignKey(
                name: "FK_Destino_PacoteTuristico_PacoteTuristicoId",
                table: "Destino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destino",
                table: "Destino");

            migrationBuilder.RenameTable(
                name: "Destino",
                newName: "Destinos");

            migrationBuilder.RenameIndex(
                name: "IX_Destino_CidadeDestinoId",
                table: "Destinos",
                newName: "IX_Destinos_CidadeDestinoId");

            migrationBuilder.AlterColumn<int>(
                name: "PaisDestinoId",
                table: "CidadeDestinos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos",
                columns: new[] { "PacoteTuristicoId", "CidadeDestinoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CidadeDestinos_PaisDestino_PaisDestinoId",
                table: "CidadeDestinos",
                column: "PaisDestinoId",
                principalTable: "PaisDestino",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_CidadeDestinos_CidadeDestinoId",
                table: "Destinos",
                column: "CidadeDestinoId",
                principalTable: "CidadeDestinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinos_PacoteTuristico_PacoteTuristicoId",
                table: "Destinos",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CidadeDestinos_PaisDestino_PaisDestinoId",
                table: "CidadeDestinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_CidadeDestinos_CidadeDestinoId",
                table: "Destinos");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinos_PacoteTuristico_PacoteTuristicoId",
                table: "Destinos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinos",
                table: "Destinos");

            migrationBuilder.RenameTable(
                name: "Destinos",
                newName: "Destino");

            migrationBuilder.RenameIndex(
                name: "IX_Destinos_CidadeDestinoId",
                table: "Destino",
                newName: "IX_Destino_CidadeDestinoId");

            migrationBuilder.AlterColumn<int>(
                name: "PaisDestinoId",
                table: "CidadeDestinos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destino",
                table: "Destino",
                columns: new[] { "PacoteTuristicoId", "CidadeDestinoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CidadeDestinos_PaisDestino_PaisDestinoId",
                table: "CidadeDestinos",
                column: "PaisDestinoId",
                principalTable: "PaisDestino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Destino_CidadeDestinos_CidadeDestinoId",
                table: "Destino",
                column: "CidadeDestinoId",
                principalTable: "CidadeDestinos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Destino_PacoteTuristico_PacoteTuristicoId",
                table: "Destino",
                column: "PacoteTuristicoId",
                principalTable: "PacoteTuristico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
