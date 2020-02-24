using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class UpdateHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Historys",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Historys",
                table: "Historys",
                column: "Id");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Historys",
                table: "Historys");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Historys");
        }
    }
}
