using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicioEstudiantil.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNuevosModulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Profesores_ProfesorId",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Titulaciones_TitulacionId",
                table: "Asignaturas");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_ProfesorId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Asignaturas");

            migrationBuilder.RenameColumn(
                name: "CorreoContacto",
                table: "Profesores",
                newName: "Identificacion");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Profesores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TitulacionId",
                table: "Asignaturas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Asignaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Asignaturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Titulaciones_TitulacionId",
                table: "Asignaturas",
                column: "TitulacionId",
                principalTable: "Titulaciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Titulaciones_TitulacionId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Asignaturas");

            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Profesores",
                newName: "CorreoContacto");

            migrationBuilder.AlterColumn<int>(
                name: "TitulacionId",
                table: "Asignaturas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfesorId",
                table: "Asignaturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_ProfesorId",
                table: "Asignaturas",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Profesores_ProfesorId",
                table: "Asignaturas",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Titulaciones_TitulacionId",
                table: "Asignaturas",
                column: "TitulacionId",
                principalTable: "Titulaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
