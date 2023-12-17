using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class propertyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a4db8f7c-06d7-4b1b-b0dd-248491d5efe9"));

            migrationBuilder.AddColumn<string>(
                name: "Lat",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lng",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(1802), new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(1804) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(2390), new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(2392) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("be7b29d7-c3ae-4105-be8c-789d5660764f"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(276), new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(822) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(3044), new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(3046) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(3635), new DateTime(2023, 5, 16, 0, 37, 38, 189, DateTimeKind.Utc).AddTicks(3637) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("be7b29d7-c3ae-4105-be8c-789d5660764f"));

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(6457), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7047), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7049) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a4db8f7c-06d7-4b1b-b0dd-248491d5efe9"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(5031), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(5595) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7603), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(8145), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(8146) });
        }
    }
}
