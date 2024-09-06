using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProEventos.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNomeTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociai_Evento_EventoId",
                table: "RedesSociai");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSociai_Palestrante_PalestranteId",
                table: "RedesSociai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedesSociai",
                table: "RedesSociai");

            migrationBuilder.RenameTable(
                name: "RedesSociai",
                newName: "RedesSocial");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSociai_PalestranteId",
                table: "RedesSocial",
                newName: "IX_RedesSocial_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSociai_EventoId",
                table: "RedesSocial",
                newName: "IX_RedesSocial_EventoId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MiniCurriculo",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemURL",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "QtdPessoas",
                table: "Evento",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemURL",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "RedesSocial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PalestranteId",
                table: "RedesSocial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "RedesSocial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "RedesSocial",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedesSocial",
                table: "RedesSocial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocial_Evento_EventoId",
                table: "RedesSocial",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSocial_Palestrante_PalestranteId",
                table: "RedesSocial",
                column: "PalestranteId",
                principalTable: "Palestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocial_Evento_EventoId",
                table: "RedesSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_RedesSocial_Palestrante_PalestranteId",
                table: "RedesSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RedesSocial",
                table: "RedesSocial");

            migrationBuilder.RenameTable(
                name: "RedesSocial",
                newName: "RedesSociai");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSocial_PalestranteId",
                table: "RedesSociai",
                newName: "IX_RedesSociai_PalestranteId");

            migrationBuilder.RenameIndex(
                name: "IX_RedesSocial_EventoId",
                table: "RedesSociai",
                newName: "IX_RedesSociai_EventoId");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiniCurriculo",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemURL",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Palestrante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tema",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QtdPessoas",
                table: "Evento",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemURL",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Evento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL",
                table: "RedesSociai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PalestranteId",
                table: "RedesSociai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "RedesSociai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "RedesSociai",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RedesSociai",
                table: "RedesSociai",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociai_Evento_EventoId",
                table: "RedesSociai",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedesSociai_Palestrante_PalestranteId",
                table: "RedesSociai",
                column: "PalestranteId",
                principalTable: "Palestrante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
