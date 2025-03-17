using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseController.Migrations
{
    /// <inheritdoc />
    public partial class FixConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUser_Courses_CoursesId",
                table: "CourseUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseUser_Users_UsersId",
                table: "CourseUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUser",
                table: "CourseUser");

            migrationBuilder.RenameTable(
                name: "CourseUser",
                newName: "UserCourses");

            migrationBuilder.RenameIndex(
                name: "IX_CourseUser_UsersId",
                table: "UserCourses",
                newName: "IX_UserCourses_UsersId");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses",
                columns: new[] { "CoursesId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Courses_CoursesId",
                table: "UserCourses",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UsersId",
                table: "UserCourses",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Courses_CoursesId",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UsersId",
                table: "UserCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourses",
                table: "UserCourses");

            migrationBuilder.RenameTable(
                name: "UserCourses",
                newName: "CourseUser");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourses_UsersId",
                table: "CourseUser",
                newName: "IX_CourseUser_UsersId");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Courses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseUser",
                table: "CourseUser",
                columns: new[] { "CoursesId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUser_Courses_CoursesId",
                table: "CourseUser",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUser_Users_UsersId",
                table: "CourseUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
