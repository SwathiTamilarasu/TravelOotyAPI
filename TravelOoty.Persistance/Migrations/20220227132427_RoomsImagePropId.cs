using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomsImagePropId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("bece35a0-6a33-450d-a296-87b4d69c21a1"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(6338), new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(6344) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(7558), new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("cae5fd7e-d1ee-4473-98f7-99bde54829a2"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(3126), new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(4423) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(8975), new DateTime(2022, 2, 27, 13, 24, 27, 58, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 24, 27, 59, DateTimeKind.Utc).AddTicks(27), new DateTime(2022, 2, 27, 13, 24, 27, 59, DateTimeKind.Utc).AddTicks(31) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("cae5fd7e-d1ee-4473-98f7-99bde54829a2"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(9880), new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(9885) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(1368), new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("bece35a0-6a33-450d-a296-87b4d69c21a1"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(7445), new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(3472), new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(5420), new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(5424) });
        }
    }
}
