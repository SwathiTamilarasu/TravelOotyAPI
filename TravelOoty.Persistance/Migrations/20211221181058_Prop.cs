using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class Prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("cdccea0e-241b-4471-bca3-df01a5157940"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(6620), new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(6624) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(7565), new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(7568) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("44fdbf5a-609e-48f8-80a3-288895c089be"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 21, 18, 10, 57, 540, DateTimeKind.Utc).AddTicks(796), new DateTime(2021, 12, 21, 18, 10, 57, 540, DateTimeKind.Utc).AddTicks(798) });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(4524), new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(8473), new DateTime(2021, 12, 21, 18, 10, 57, 539, DateTimeKind.Utc).AddTicks(8476) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("44fdbf5a-609e-48f8-80a3-288895c089be"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("cdccea0e-241b-4471-bca3-df01a5157940"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { null, null });
        }
    }
}
