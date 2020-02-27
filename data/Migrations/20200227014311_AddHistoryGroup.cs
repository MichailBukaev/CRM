using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AddHistoryGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryGroups_Groups_GroupId",
                table: "HistoryGroups");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HistoryGroups");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "HistoryGroups",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryGroups_Groups_GroupId",
                table: "HistoryGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryGroups_Groups_GroupId",
                table: "HistoryGroups");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "HistoryGroups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HistoryGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryGroups_Groups_GroupId",
                table: "HistoryGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
