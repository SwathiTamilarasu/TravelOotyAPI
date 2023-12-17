using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomPropertyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("b5dffcf6-449d-4154-bf1f-cffa78580d05"));

            migrationBuilder.AlterColumn<decimal>(
                name: "SpecialPrice",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RegularPrice",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(5145), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(6714), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("ff69fa50-49e8-4d41-9834-c4dd9baebdde"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(2280), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(7961), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(7964) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(8980), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(8983) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("ff69fa50-49e8-4d41-9834-c4dd9baebdde"));

            migrationBuilder.AlterColumn<string>(
                name: "SpecialPrice",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "RegularPrice",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
    }
}
