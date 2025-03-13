using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CampSleepAwayDB.Migrations
{
    /// <inheritdoc />
    public partial class seedchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 1,
                column: "Name",
                value: "Pine Lodge");

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 2,
                column: "Name",
                value: "Maple Retreat");

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 3,
                column: "Name",
                value: "Oak Haven");

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CabinId", "EndDate" },
                values: new object[] { 1, null });

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 5,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 6,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CabinId", "EndDate" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CabinId", "EndDate" },
                values: new object[] { 2, null });

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 9,
                column: "EndDate",
                value: null);

            migrationBuilder.InsertData(
                table: "CamperCabinAssignments",
                columns: new[] { "Id", "CabinId", "CamperId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 10, 3, 10, null, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 3, 11, null, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3, 12, null, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 1,
                column: "Name",
                value: "Alice Brown");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 2,
                column: "Name",
                value: "Bob White");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 3,
                column: "Name",
                value: "Charlie Green");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 4,
                column: "Name",
                value: "Daisy Blue");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 5,
                column: "Name",
                value: "Ethan Black");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 6,
                column: "Name",
                value: "Fiona Gray");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 7,
                column: "Name",
                value: "George Red");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 8,
                column: "Name",
                value: "Hannah Yellow");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 9,
                column: "Name",
                value: "Ian Purple");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 10,
                column: "Name",
                value: "Jack Orange");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 11,
                column: "Name",
                value: "Katie Pink");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 12,
                column: "Name",
                value: "Liam Cyan");

            migrationBuilder.UpdateData(
                table: "CounselorCabinAssignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CounselorCabinAssignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "CounselorCabinAssignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "EndDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 1,
                column: "Name",
                value: "John Smith");

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 2,
                column: "Name",
                value: "Jane Doe");

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 3,
                column: "Name",
                value: "Emily Johnson");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 1,
                column: "Name",
                value: "Sarah Brown");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 2,
                column: "Name",
                value: "Tom White");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 3,
                column: "Name",
                value: "Ursula Green");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 4,
                column: "Name",
                value: "Victor Blue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 1,
                column: "Name",
                value: "Cabin 1");

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 2,
                column: "Name",
                value: "Cabin 2");

            migrationBuilder.UpdateData(
                table: "Cabins",
                keyColumn: "CabinId",
                keyValue: 3,
                column: "Name",
                value: "Cabin 3");

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CabinId", "EndDate" },
                values: new object[] { 2, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 5,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 6,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CabinId", "EndDate" },
                values: new object[] { 3, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CabinId", "EndDate" },
                values: new object[] { 3, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "CamperCabinAssignments",
                keyColumn: "Id",
                keyValue: 9,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 1,
                column: "Name",
                value: "Camper 1");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 2,
                column: "Name",
                value: "Camper 2");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 3,
                column: "Name",
                value: "Camper 3");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 4,
                column: "Name",
                value: "Camper 4");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 5,
                column: "Name",
                value: "Camper 5");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 6,
                column: "Name",
                value: "Camper 6");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 7,
                column: "Name",
                value: "Camper 7");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 8,
                column: "Name",
                value: "Camper 8");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 9,
                column: "Name",
                value: "Camper 9");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 10,
                column: "Name",
                value: "Camper 10");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 11,
                column: "Name",
                value: "Camper 11");

            migrationBuilder.UpdateData(
                table: "Campers",
                keyColumn: "CamperId",
                keyValue: 12,
                column: "Name",
                value: "Camper 12");

            migrationBuilder.InsertData(
                table: "Campers",
                columns: new[] { "CamperId", "Name" },
                values: new object[,]
                {
                    { 13, "Camper 13" },
                    { 14, "Camper 14" },
                    { 15, "Camper 15" },
                    { 16, "Camper 16" },
                    { 17, "Camper 17" },
                    { 18, "Camper 18" }
                });

            migrationBuilder.UpdateData(
                table: "CounselorCabinAssignments",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CounselorCabinAssignments",
                keyColumn: "Id",
                keyValue: 2,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CounselorCabinAssignments",
                keyColumn: "Id",
                keyValue: 3,
                column: "EndDate",
                value: new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 1,
                column: "Name",
                value: "Counselor 1");

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 2,
                column: "Name",
                value: "Counselor 2");

            migrationBuilder.UpdateData(
                table: "Counselors",
                keyColumn: "CounselorId",
                keyValue: 3,
                column: "Name",
                value: "Counselor 3");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 1,
                column: "Name",
                value: "NextOfKin 1");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 2,
                column: "Name",
                value: "NextOfKin 2");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 3,
                column: "Name",
                value: "NextOfKin 3");

            migrationBuilder.UpdateData(
                table: "NextOfKins",
                keyColumn: "NextOfKinId",
                keyValue: 4,
                column: "Name",
                value: "NextOfKin 4");
        }
    }
}
