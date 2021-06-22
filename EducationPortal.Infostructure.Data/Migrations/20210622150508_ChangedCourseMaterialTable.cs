using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationPortal.Persistence.Migrations
{
    public partial class ChangedCourseMaterialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterial_Course_CourseId",
                schema: "sch",
                table: "CourseMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterial_Material_MaterialId",
                schema: "sch",
                table: "CourseMaterial");

            migrationBuilder.DropIndex(
                name: "IX_CourseMaterial_CourseId",
                schema: "sch",
                table: "CourseMaterial");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                schema: "sch",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                schema: "sch",
                table: "CourseMaterial",
                newName: "MaterialsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "sch",
                table: "CourseMaterial",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMaterial_MaterialId",
                schema: "sch",
                table: "CourseMaterial",
                newName: "IX_CourseMaterial_MaterialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseMaterial",
                schema: "sch",
                table: "CourseMaterial",
                columns: new[] { "CoursesId", "MaterialsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterial_Courses_CoursesId",
                schema: "sch",
                table: "CourseMaterial",
                column: "CoursesId",
                principalSchema: "sch",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterial_Materials_MaterialsId",
                schema: "sch",
                table: "CourseMaterial",
                column: "MaterialsId",
                principalSchema: "sch",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterial_Courses_CoursesId",
                schema: "sch",
                table: "CourseMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseMaterial_Materials_MaterialsId",
                schema: "sch",
                table: "CourseMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseMaterial",
                schema: "sch",
                table: "CourseMaterial");

            migrationBuilder.RenameColumn(
                name: "MaterialsId",
                schema: "sch",
                table: "CourseMaterial",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                schema: "sch",
                table: "CourseMaterial",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseMaterial_MaterialsId",
                schema: "sch",
                table: "CourseMaterial",
                newName: "IX_CourseMaterial_MaterialId");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                schema: "sch",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaterial_CourseId",
                schema: "sch",
                table: "CourseMaterial",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterial_Course_CourseId",
                schema: "sch",
                table: "CourseMaterial",
                column: "CourseId",
                principalSchema: "sch",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMaterial_Material_MaterialId",
                schema: "sch",
                table: "CourseMaterial",
                column: "MaterialId",
                principalSchema: "sch",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
