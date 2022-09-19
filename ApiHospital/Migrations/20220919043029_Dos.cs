using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiHospital.Migrations
{
    public partial class Dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Hospitales");

            migrationBuilder.AddColumn<string>(
                name: "NombreHospital",
                table: "Hospitales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreHospital",
                table: "Hospitales");

            migrationBuilder.AddColumn<int>(
                name: "Nombre",
                table: "Hospitales",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
