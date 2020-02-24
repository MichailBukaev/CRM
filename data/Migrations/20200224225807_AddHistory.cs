using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class AddHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historys",
                columns: table => new
                {
                    LeadId = table.Column<int>(nullable: false),
                    HistoryText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Historys_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
