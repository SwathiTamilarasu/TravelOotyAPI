using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class PropertyPhNoCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("c9692f8c-b07b-4d87-a41e-ec71beb5d8a1"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(1925), new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(1928) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(2527), new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(2530) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("51fd5507-2765-4b40-a815-5d5c820ebb7f"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(526), new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(3099), new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(3102) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(3664), new DateTime(2022, 4, 30, 18, 38, 39, 137, DateTimeKind.Utc).AddTicks(3667) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("51fd5507-2765-4b40-a815-5d5c820ebb7f"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(5399), new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(5403) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(6363), new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(6366) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("c9692f8c-b07b-4d87-a41e-ec71beb5d8a1"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(3214), new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(7284), new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(8338), new DateTime(2022, 4, 24, 4, 16, 42, 879, DateTimeKind.Utc).AddTicks(8341) });
        }
    }
}
