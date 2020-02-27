using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AddPKHIstoryGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HistoryGroups",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryGroups",
                table: "HistoryGroups",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryGroups",
                table: "HistoryGroups");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HistoryGroups");
        }
    }
}
