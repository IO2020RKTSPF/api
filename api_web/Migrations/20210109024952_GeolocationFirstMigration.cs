using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class GeolocationFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Books",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Books",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Books");
        }
    }
}
