using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystemBackend.Migrations
{
    /// <inheritdoc />
    public partial class StudentsNextOfKin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserNextKins");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "NextOfKins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentNextOfKins",
                columns: table => new
                {
                    NextOfKinsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNextOfKins", x => new { x.NextOfKinsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentNextOfKins_AppUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentNextOfKins_NextOfKins_NextOfKinsId",
                        column: x => x.NextOfKinsId,
                        principalTable: "NextOfKins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_StaffId",
                table: "NextOfKins",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNextOfKins_StudentsId",
                table: "StudentNextOfKins",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKins_AppUsers_StaffId",
                table: "NextOfKins",
                column: "StaffId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKins_AppUsers_StaffId",
                table: "NextOfKins");

            migrationBuilder.DropTable(
                name: "StudentNextOfKins");

            migrationBuilder.DropIndex(
                name: "IX_NextOfKins_StaffId",
                table: "NextOfKins");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "NextOfKins");

            migrationBuilder.CreateTable(
                name: "AppUserNextKins",
                columns: table => new
                {
                    AppUsersId = table.Column<int>(type: "int", nullable: false),
                    NextOfKinsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserNextKins", x => new { x.AppUsersId, x.NextOfKinsId });
                    table.ForeignKey(
                        name: "FK_AppUserNextKins_AppUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserNextKins_NextOfKins_NextOfKinsId",
                        column: x => x.NextOfKinsId,
                        principalTable: "NextOfKins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserNextKins_NextOfKinsId",
                table: "AppUserNextKins",
                column: "NextOfKinsId");
        }
    }
}
