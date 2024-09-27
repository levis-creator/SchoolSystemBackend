using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Departments_DepartmentId",
                table: "AppUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Departments_DepartmentId",
                table: "AppUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Departments_DepartmentId",
                table: "AppUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Departments_DepartmentId",
                table: "AppUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
