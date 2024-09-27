using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class Department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DepartmentId",
                table: "AppUsers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Departments_DepartmentId",
                table: "AppUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Departments_DepartmentId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_DepartmentId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
