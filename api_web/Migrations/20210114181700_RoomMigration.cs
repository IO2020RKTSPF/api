using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class RoomMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "Transactions",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Transactions");
        }
    }
}
