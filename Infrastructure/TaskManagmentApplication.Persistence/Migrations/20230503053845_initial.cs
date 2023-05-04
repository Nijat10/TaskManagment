using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentApplication.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXERCISES",
                columns: table => new
                {
                    TASKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STARTDATE = table.Column<DateTime>(type: "date", nullable: false),
                    ENDDATE = table.Column<DateTime>(type: "date", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCISES", x => x.TASKID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LASTNAME = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ROLE = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONFIRMPASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IMAGES",
                columns: table => new
                {
                    IMAGEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGEURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TASKID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGES", x => x.IMAGEID);
                    table.ForeignKey(
                        name: "FK_Images_Exercises",
                        column: x => x.TASKID,
                        principalTable: "EXERCISES",
                        principalColumn: "TASKID");
                });

            migrationBuilder.CreateTable(
                name: "TASKASSIGNS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TASKID = table.Column<int>(type: "int", nullable: false),
                    USERID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TASKASSIGNS", x => x.ID);
                    table.ForeignKey(
                        name: "FK__TASKASSIG__USERI__2F10007B",
                        column: x => x.TASKID,
                        principalTable: "EXERCISES",
                        principalColumn: "TASKID");
                    table.ForeignKey(
                        name: "FK__TASKASSIG__USERI__300424B4",
                        column: x => x.USERID,
                        principalTable: "USERS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMAGES_TASKID",
                table: "IMAGES",
                column: "TASKID");

            migrationBuilder.CreateIndex(
                name: "IX_TASKASSIGNS_TASKID",
                table: "TASKASSIGNS",
                column: "TASKID");

            migrationBuilder.CreateIndex(
                name: "IX_TASKASSIGNS_USERID",
                table: "TASKASSIGNS",
                column: "USERID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMAGES");

            migrationBuilder.DropTable(
                name: "TASKASSIGNS");

            migrationBuilder.DropTable(
                name: "EXERCISES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
