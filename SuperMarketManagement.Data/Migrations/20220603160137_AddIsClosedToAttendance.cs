using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarketManagement.Data.Migrations
{
    public partial class AddIsClosedToAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "AdminAttendances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "AdminAttendances");
        }
    }
}
