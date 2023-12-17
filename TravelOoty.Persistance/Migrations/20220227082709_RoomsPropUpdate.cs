using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomsPropUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("f3f73641-81eb-4e89-91f9-aa4956d6d83b"));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(7312), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(8392), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("9ec16b8e-8ab0-4d94-8b47-3b25acee7b23"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(4809), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(9452), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 872, DateTimeKind.Utc).AddTicks(509), new DateTime(2022, 2, 27, 8, 27, 8, 872, DateTimeKind.Utc).AddTicks(513) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("9ec16b8e-8ab0-4d94-8b47-3b25acee7b23"));

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 26, 14, 37, 7, 397, DateTimeKind.Utc).AddTicks(8885), new DateTime(2022, 2, 26, 14, 37, 7, 397, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 26, 14, 37, 7, 398, DateTimeKind.Utc).AddTicks(465), new DateTime(2022, 2, 26, 14, 37, 7, 398, DateTimeKind.Utc).AddTicks(471) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("f3f73641-81eb-4e89-91f9-aa4956d6d83b"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 26, 14, 37, 7, 397, DateTimeKind.Utc).AddTicks(4567), new DateTime(2022, 2, 26, 14, 37, 7, 397, DateTimeKind.Utc).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 26, 14, 37, 7, 398, DateTimeKind.Utc).AddTicks(2000), new DateTime(2022, 2, 26, 14, 37, 7, 398, DateTimeKind.Utc).AddTicks(2006) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 26, 14, 37, 7, 398, DateTimeKind.Utc).AddTicks(3493), new DateTime(2022, 2, 26, 14, 37, 7, 398, DateTimeKind.Utc).AddTicks(3499) });
        }
    }
}
