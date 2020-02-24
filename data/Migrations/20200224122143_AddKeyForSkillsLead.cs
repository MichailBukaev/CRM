using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AddKeyForSkillsLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SkillsLeads",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillsLeads",
                table: "SkillsLeads",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillsLeads",
                table: "SkillsLeads");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SkillsLeads");
        }
    }
}
