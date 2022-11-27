using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiHospital.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermedads_AspNetUsers_UsuarioId",
                table: "Enfermedads");

            migrationBuilder.DropForeignKey(
                name: "FK_Enfermedads_Pacientes_PacienteIdPaciente",
                table: "Enfermedads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enfermedads",
                table: "Enfermedads");

            migrationBuilder.RenameTable(
                name: "Enfermedads",
                newName: "Enfermedades");

            migrationBuilder.RenameIndex(
                name: "IX_Enfermedads_UsuarioId",
                table: "Enfermedades",
                newName: "IX_Enfermedades_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Enfermedads_PacienteIdPaciente",
                table: "Enfermedades",
                newName: "IX_Enfermedades_PacienteIdPaciente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enfermedades",
                table: "Enfermedades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermedades_AspNetUsers_UsuarioId",
                table: "Enfermedades",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermedades_Pacientes_PacienteIdPaciente",
                table: "Enfermedades",
                column: "PacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermedades_AspNetUsers_UsuarioId",
                table: "Enfermedades");

            migrationBuilder.DropForeignKey(
                name: "FK_Enfermedades_Pacientes_PacienteIdPaciente",
                table: "Enfermedades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enfermedades",
                table: "Enfermedades");

            migrationBuilder.RenameTable(
                name: "Enfermedades",
                newName: "Enfermedads");

            migrationBuilder.RenameIndex(
                name: "IX_Enfermedades_UsuarioId",
                table: "Enfermedads",
                newName: "IX_Enfermedads_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Enfermedades_PacienteIdPaciente",
                table: "Enfermedads",
                newName: "IX_Enfermedads_PacienteIdPaciente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enfermedads",
                table: "Enfermedads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermedads_AspNetUsers_UsuarioId",
                table: "Enfermedads",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermedads_Pacientes_PacienteIdPaciente",
                table: "Enfermedads",
                column: "PacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");
        }
    }
}
