using Microsoft.EntityFrameworkCore.Migrations;

namespace _5_15_SignalRTasks.data.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Chores",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Chores",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
