using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CampSleepAwayDB.Migrations
{
    /// <inheritdoc />
    public partial class seedupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Counselors_CounselorId",
                table: "Cabins");

            migrationBuilder.DropForeignKey(
                name: "FK_Campers_Cabins_CabinId",
                table: "Campers");

            migrationBuilder.DropIndex(
                name: "IX_Campers_CabinId",
                table: "Campers");

            migrationBuilder.DropIndex(
                name: "IX_Cabins_CounselorId",
                table: "Cabins");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "Campers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Campers");

            migrationBuilder.DropColumn(
                name: "CounselorId",
                table: "Cabins");

            migrationBuilder.CreateTable(
                name: "CamperCabinAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperCabinAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CamperCabinAssignments_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamperCabinAssignments_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "CamperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CounselorCabinAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounselorId = table.Column<int>(type: "int", nullable: false),
                    CabinId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounselorCabinAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounselorCabinAssignments_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CounselorCabinAssignments_Counselors_CounselorId",
                        column: x => x.CounselorId,
                        principalTable: "Counselors",
                        principalColumn: "CounselorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CamperCabinAssignments",
                columns: new[] { "Id", "CabinId", "CamperId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 2, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 3, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 4, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, 5, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, 6, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, 7, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, 8, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, 9, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CounselorCabinAssignments",
                columns: new[] { "Id", "CabinId", "CounselorId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 1,
                column: "EmploymentDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 2,
                column: "EmploymentDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 3,
                column: "EmploymentDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_CamperCabinAssignments_CabinId",
                table: "CamperCabinAssignments",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_CamperCabinAssignments_CamperId",
                table: "CamperCabinAssignments",
                column: "CamperId");

            migrationBuilder.CreateIndex(
                name: "IX_CounselorCabinAssignments_CabinId",
                table: "CounselorCabinAssignments",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_CounselorCabinAssignments_CounselorId",
                table: "CounselorCabinAssignments",
                column: "CounselorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamperCabinAssignments");

            migrationBuilder.DropTable(
                name: "CounselorCabinAssignments");

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "Counselors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "Campers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Campers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CounselorId",
                table: "Cabins",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 1,
                column: "CounselorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 2,
                column: "CounselorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 3,
                column: "CounselorId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 1,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 1, new DateTime(2015, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 2,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 1, new DateTime(2014, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1152) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 3,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 1, new DateTime(2013, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 4,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 2, new DateTime(2012, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1163) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 5,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 2, new DateTime(2011, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1166) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 6,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 2, new DateTime(2010, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 7,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 3, new DateTime(2009, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1171) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 8,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 3, new DateTime(2008, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 9,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 3, new DateTime(2007, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1176) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 10,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 1, new DateTime(2006, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 11,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 1, new DateTime(2005, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1180) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 12,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 1, new DateTime(2004, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1183) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 13,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 2, new DateTime(2003, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1185) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 14,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 2, new DateTime(2002, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1187) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 15,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 2, new DateTime(2001, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 16,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 3, new DateTime(2000, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1192) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 17,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 3, new DateTime(1999, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 18,
                columns: new[] { "CabinId", "DateOfBirth" },
                values: new object[] { 3, new DateTime(1998, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 1,
                columns: new[] { "CabinId", "EmploymentDate" },
                values: new object[] { 1, new DateTime(2025, 3, 10, 23, 27, 56, 954, DateTimeKind.Local).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 2,
                columns: new[] { "CabinId", "EmploymentDate" },
                values: new object[] { 2, new DateTime(2025, 3, 10, 23, 27, 56, 957, DateTimeKind.Local).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 3,
                columns: new[] { "CabinId", "EmploymentDate" },
                values: new object[] { 3, new DateTime(2025, 3, 10, 23, 27, 56, 957, DateTimeKind.Local).AddTicks(9578) });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinId",
                table: "Campers",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CounselorId",
                table: "Cabins",
                column: "CounselorId",
                unique: true,
                filter: "[CounselorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Counselors_CounselorId",
                table: "Cabins",
                column: "CounselorId",
                principalTable: "Counselors",
                principalColumn: "CounselorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campers_Cabins_CabinId",
                table: "Campers",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId");
        }
    }
}
