using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("cfdbba8a-a348-473c-9a71-e650171e42fb"));

            migrationBuilder.AddColumn<string>(
                name: "CancellationPolicy",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberOfRoomsCategory",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(7701), new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(7705) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(8891), new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(8894) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("b5dffcf6-449d-4154-bf1f-cffa78580d05"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(4988), new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(5826) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(9878), new DateTime(2022, 6, 4, 7, 30, 14, 720, DateTimeKind.Utc).AddTicks(9880) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 30, 14, 721, DateTimeKind.Utc).AddTicks(977), new DateTime(2022, 6, 4, 7, 30, 14, 721, DateTimeKind.Utc).AddTicks(979) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("b5dffcf6-449d-4154-bf1f-cffa78580d05"));

            migrationBuilder.DropColumn(
                name: "CancellationPolicy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NumberOfRoomsCategory",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(3191), new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(3195) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(4192), new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(4194) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("cfdbba8a-a348-473c-9a71-e650171e42fb"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(828), new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(5151), new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(6093), new DateTime(2022, 6, 4, 7, 16, 33, 64, DateTimeKind.Utc).AddTicks(6096) });
        }
    }
}
