using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class propertyUpdateApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("51fd5507-2765-4b40-a815-5d5c820ebb7f"));

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("f1930807-32a4-4403-8f4c-a2263fa787ab"));

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Properties");

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
    }
}
