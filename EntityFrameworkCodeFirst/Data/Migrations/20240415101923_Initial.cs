using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkCodeFirst.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplicationsReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Reason = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplicationsReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LeaveApplicationReasonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_LeaveApplicationsReasons_LeaveApplicationReasonId",
                        column: x => x.LeaveApplicationReasonId,
                        principalTable: "LeaveApplicationsReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserRoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Johan", "Edlund" },
                    { 2, "Heikki", "Wallenberg" },
                    { 3, "Leo", "Andersson" },
                    { 4, "Ellen", "Blixt" }
                });

            migrationBuilder.InsertData(
                table: "LeaveApplicationsReasons",
                columns: new[] { "Id", "Reason" },
                values: new object[,]
                {
                    { 1, "Sick Leave" },
                    { 2, "Vacation" },
                    { 3, "Parental Leave" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Role" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "LeaveApplications",
                columns: new[] { "Id", "CreationDate", "EmployeeId", "EndDate", "LeaveApplicationReasonId", "Note", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(308), 1, new DateTime(2024, 5, 13, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(305), 2, "I can't take this job anymore. I need a break.", new DateTime(2024, 4, 15, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(266) },
                    { 2, new DateTime(2024, 4, 15, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(313), 2, new DateTime(2024, 4, 16, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(312), 3, "I need to stay home and care for my sick child for a couple of days.", new DateTime(2024, 4, 14, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(311) },
                    { 3, new DateTime(2024, 4, 15, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(316), 3, new DateTime(2024, 4, 20, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(315), 1, "I must have caught the flu. I'll be out of commission for a while.", new DateTime(2024, 4, 8, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(314) },
                    { 4, new DateTime(2024, 4, 15, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(320), 4, new DateTime(2024, 4, 14, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(319), 4, null, new DateTime(2024, 4, 12, 12, 19, 22, 892, DateTimeKind.Local).AddTicks(318) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmployeeId", "Password", "UserRoleId" },
                values: new object[,]
                {
                    { 1, "a@a.a", 1, "123", 1 },
                    { 2, "heikki@gmail.com", 2, "123", 2 },
                    { 3, "leo@live.com", 3, "123", 2 },
                    { 4, "ellen@hotmail.com", 4, "123", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_LeaveApplicationReasonId",
                table: "LeaveApplications",
                column: "LeaveApplicationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveApplications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LeaveApplicationsReasons");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
