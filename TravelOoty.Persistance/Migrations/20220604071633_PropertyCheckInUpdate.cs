using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class PropertyCheckInUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("f1930807-32a4-4403-8f4c-a2263fa787ab"));

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckInOut",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FrontDeskTime",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IfscCode",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyDesc",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("cfdbba8a-a348-473c-9a71-e650171e42fb"));

            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CheckInOut",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FrontDeskTime",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IfscCode",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyDesc",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(4097), new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(5373), new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(5376) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("f1930807-32a4-4403-8f4c-a2263fa787ab"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(812), new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(2016) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(6530), new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(6534) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(7659), new DateTime(2022, 5, 1, 16, 14, 6, 356, DateTimeKind.Utc).AddTicks(7662) });
        }
    }
}
