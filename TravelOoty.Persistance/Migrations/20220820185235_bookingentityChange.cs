using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class bookingentityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("486d1bce-f80e-4bac-907c-e4abce28da5b"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(5541), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(5545) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(6605), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(6608) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a3876732-28f0-4b3f-843a-bdbcb7374802"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(1798), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(3371) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(7981), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(9745), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(9749) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a3876732-28f0-4b3f-843a-bdbcb7374802"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(3582), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(3586) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(4577), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("486d1bce-f80e-4bac-907c-e4abce28da5b"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(1356), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(5589), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(6507), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(6510) });
        }
    }
}
