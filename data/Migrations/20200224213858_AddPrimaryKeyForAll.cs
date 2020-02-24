using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AddPrimaryKeyForAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Historys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HistoryGroups",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Historys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HistoryGroups");
        }
    }
}
