using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CampSleepAwayDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    CounselorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CabinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.CounselorId);
                });

            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    CounselorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_Cabins_Counselors_CounselorId",
                        column: x => x.CounselorId,
                        principalTable: "Counselors",
                        principalColumn: "CounselorId");
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    CamperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CabinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.CamperId);
                    table.ForeignKey(
                        name: "FK_Campers_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId");
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CamperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinId);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Campers_CamperId",
                        column: x => x.CamperId,
                        principalTable: "Campers",
                        principalColumn: "CamperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cabins",
                columns: new[] { "CabinId", "CounselorId", "MaxCapacity", "Name" },
                values: new object[,]
                {
                    { 1, null, 4, "Cabin 1" },
                    { 2, null, 4, "Cabin 2" },
                    { 3, null, 4, "Cabin 3" }
                });

            migrationBuilder.InsertData(
                table: "Counselors",
                columns: new[] { "CounselorId", "CabinId", "EmploymentDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 10, 23, 27, 56, 954, DateTimeKind.Local).AddTicks(6109), "Counselor 1" },
                    { 2, 2, new DateTime(2025, 3, 10, 23, 27, 56, 957, DateTimeKind.Local).AddTicks(9556), "Counselor 2" },
                    { 3, 3, new DateTime(2025, 3, 10, 23, 27, 56, 957, DateTimeKind.Local).AddTicks(9578), "Counselor 3" }
                });

            migrationBuilder.InsertData(
                table: "Campers",
                columns: new[] { "CamperId", "CabinId", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2015, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(667), "Camper 1" },
                    { 2, 1, new DateTime(2014, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1152), "Camper 2" },
                    { 3, 1, new DateTime(2013, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1161), "Camper 3" },
                    { 4, 2, new DateTime(2012, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1163), "Camper 4" },
                    { 5, 2, new DateTime(2011, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1166), "Camper 5" },
                    { 6, 2, new DateTime(2010, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1169), "Camper 6" },
                    { 7, 3, new DateTime(2009, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1171), "Camper 7" },
                    { 8, 3, new DateTime(2008, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1173), "Camper 8" },
                    { 9, 3, new DateTime(2007, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1176), "Camper 9" },
                    { 10, 1, new DateTime(2006, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1178), "Camper 10" },
                    { 11, 1, new DateTime(2005, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1180), "Camper 11" },
                    { 12, 1, new DateTime(2004, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1183), "Camper 12" },
                    { 13, 2, new DateTime(2003, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1185), "Camper 13" },
                    { 14, 2, new DateTime(2002, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1187), "Camper 14" },
                    { 15, 2, new DateTime(2001, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1190), "Camper 15" },
                    { 16, 3, new DateTime(2000, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1192), "Camper 16" },
                    { 17, 3, new DateTime(1999, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1194), "Camper 17" },
                    { 18, 3, new DateTime(1998, 3, 10, 23, 27, 56, 958, DateTimeKind.Local).AddTicks(1197), "Camper 18" }
                });

            migrationBuilder.InsertData(
                table: "NextOfKins",
                columns: new[] { "NextOfKinId", "CamperId", "Name", "Relationship" },
                values: new object[,]
                {
                    { 1, 1, "NextOfKin 1", "Parent" },
                    { 2, 2, "NextOfKin 2", "Parent" },
                    { 3, 3, "NextOfKin 3", "Parent" },
                    { 4, 4, "NextOfKin 4", "Parent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CounselorId",
                table: "Cabins",
                column: "CounselorId",
                unique: true,
                filter: "[CounselorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Campers_CabinId",
                table: "Campers",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_CamperId",
                table: "NextOfKins",
                column: "CamperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Counselors");
        }
    }
}
