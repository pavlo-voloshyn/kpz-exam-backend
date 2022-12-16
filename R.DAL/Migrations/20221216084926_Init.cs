using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сandidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сandidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interviewers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidatId = table.Column<int>(type: "int", nullable: false),
                    InterviewerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_Interviewers_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Interviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Сandidates_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Сandidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interviewers",
                columns: new[] { "Id", "Level", "Name", "Stack", "Surname" },
                values: new object[,]
                {
                    { 1, "TL", "Taras", ".Net", "Shevchenko" },
                    { 2, "Senior Strong Architector", "Nazar", "Js", "Leshnevskiy" }
                });

            migrationBuilder.InsertData(
                table: "Сandidates",
                columns: new[] { "Id", "Level", "Name", "Stack", "Surname" },
                values: new object[,]
                {
                    { 1, "Junior Strong", "Dmytro", ".Net", "Melnyk" },
                    { 2, "Junior", "Slavko", "Js, React", "Zozuk" },
                    { 3, "Middle", "Liubomyr", "NodeJs", "Liuklian" }
                });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "Id", "CandidatId", "EndDate", "InterviewerId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 12, 25, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 12, 25, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 12, 20, 13, 30, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 12, 20, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 12, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 12, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CandidatId",
                table: "Interviews",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "Interviewers");

            migrationBuilder.DropTable(
                name: "Сandidates");
        }
    }
}
