using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCRPCC.Data.Migrations
{
    public partial class AddImageEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Empleado",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Empleado");
        }
    }
}
