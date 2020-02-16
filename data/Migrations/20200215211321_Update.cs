using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Log",
                table: "Groups");

            migrationBuilder.AddColumn<bool>(
                name: "Head",
                table: "Teacherss",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Head",
                table: "HRs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LinkTeacherCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTeacherCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkTeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkTeacherCourses_Teacherss_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacherss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkTeacherCourses_CourseId",
                table: "LinkTeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkTeacherCourses_TeacherId",
                table: "LinkTeacherCourses",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkTeacherCourses");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "Teacherss");

            migrationBuilder.DropColumn(
                name: "Head",
                table: "HRs");

            migrationBuilder.AddColumn<string>(
                name: "Log",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
