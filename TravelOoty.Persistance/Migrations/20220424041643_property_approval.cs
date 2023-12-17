using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class property_approval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("5c02ea3a-3d63-4bc2-9581-95deff72cd63"));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("c9692f8c-b07b-4d87-a41e-ec71beb5d8a1"));

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(6170), new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(8181), new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("5c02ea3a-3d63-4bc2-9581-95deff72cd63"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(1840), new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(3414) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(60), new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(2024), new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(2031) });
        }
    }
}
