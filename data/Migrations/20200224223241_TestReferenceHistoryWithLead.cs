using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class TestReferenceHistoryWithLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historys_Leads_LeadId",
                table: "Historys");

            migrationBuilder.AlterColumn<int>(
                name: "LeadId",
                table: "Historys",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Historys_Leads_LeadId",
                table: "Historys",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historys_Leads_LeadId",
                table: "Historys");

            migrationBuilder.AlterColumn<int>(
                name: "LeadId",
                table: "Historys",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historys_Leads_LeadId",
                table: "Historys",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
