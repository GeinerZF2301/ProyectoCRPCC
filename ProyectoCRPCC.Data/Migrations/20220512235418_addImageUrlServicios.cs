using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCRPCC.Data.Migrations
{
    public partial class addImageUrlServicios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Servicios");
        }
    }
}
