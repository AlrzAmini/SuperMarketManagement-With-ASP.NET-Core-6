using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperMarketManagement.Data.Migrations
{
    public partial class AddWorkMinutesToAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkTimeMinutes",
                table: "AdminAttendances",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTimeMinutes",
                table: "AdminAttendances");
        }
    }
}
