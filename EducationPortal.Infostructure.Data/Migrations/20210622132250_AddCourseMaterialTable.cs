using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationPortal.Persistence.Migrations
{
    public partial class AddCourseMaterialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Material_MaterialId",
                schema: "sch",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_MaterialId",
                schema: "sch",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseMaterial",
                schema: "sch",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CourseMaterial_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "sch",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "sch",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_CourseId",
                schema: "sch",
                table: "CourseMaterial",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_MaterialId",
                schema: "sch",
                table: "CourseMaterial",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaterial",
                schema: "sch");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_MaterialId",
                schema: "sch",
                table: "Courses",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Material_MaterialId",
                schema: "sch",
                table: "Courses",
                column: "MaterialId",
                principalSchema: "sch",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
