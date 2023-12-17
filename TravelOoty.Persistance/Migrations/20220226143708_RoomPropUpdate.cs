using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomPropUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("aaaf4d7a-f956-42a3-b7cd-64abe40589b0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Beds",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Guests",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RoomFacilityLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomFacilityLink",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RoomFacilityLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "RoomFacilityLink",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PropertyAmenitiesLinks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PropertyAmenitiesLinks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "PropertyAmenitiesLinks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "PropertyAmenitiesLinks",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("f3f73641-81eb-4e89-91f9-aa4956d6d83b"));

            migrationBuilder.DropColumn(
                name: "Beds",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Guests",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RoomFacilityLink");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RoomFacilityLink");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RoomFacilityLink");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "RoomFacilityLink");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PropertyAmenitiesLinks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PropertyAmenitiesLinks");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PropertyAmenitiesLinks");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "PropertyAmenitiesLinks");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(3040), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(3044) });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, null, new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(7133), null, new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(7136), "Ooty" });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(4900), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(4909) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("aaaf4d7a-f956-42a3-b7cd-64abe40589b0"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 492, DateTimeKind.Utc).AddTicks(9938), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(6087), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(6089) });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name", "PropertyID", "RegularPrice", "RoomCategoryId", "SpecialPrice" },
                values: new object[] { 1, null, new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(9230), null, new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(9235), "Big Boss", 0, "5000", 0, "3000" });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 494, DateTimeKind.Utc).AddTicks(979), new DateTime(2022, 2, 23, 17, 57, 49, 494, DateTimeKind.Utc).AddTicks(986) });
        }
    }
}
