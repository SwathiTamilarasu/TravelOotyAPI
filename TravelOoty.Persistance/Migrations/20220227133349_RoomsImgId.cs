using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomsImgId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("cae5fd7e-d1ee-4473-98f7-99bde54829a2"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "RoomImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(6100), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(7519), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("2e014494-0f86-417e-8749-095b2c36609c"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(2638), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(9022), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 161, DateTimeKind.Utc).AddTicks(182), new DateTime(2022, 2, 27, 13, 33, 48, 161, DateTimeKind.Utc).AddTicks(185) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("2e014494-0f86-417e-8749-095b2c36609c"));

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "RoomImages");

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
    }
}
