using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalManager.Api.Migrations
{
    public partial class UpdateRoomModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HospitalName",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalName",
                table: "Rooms");
        }
    }
}
