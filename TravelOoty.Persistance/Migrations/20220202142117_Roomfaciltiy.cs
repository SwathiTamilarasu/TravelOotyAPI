using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class Roomfaciltiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("44fdbf5a-609e-48f8-80a3-288895c089be"));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalRooms",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomsCategory",
                columns: table => new
                {
                    RoomCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsCategory", x => x.RoomCategoryId);
                });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(7307), new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(9230), new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(9234) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("c5fcc029-774d-498f-b894-fdd4cfec0d68"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(7553), new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(7556) });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(4043), new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(1432), new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.InsertData(
                table: "RoomsCategory",
                columns: new[] { "RoomCategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, null, new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(3003), null, new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(3007), "Heater" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomsCategory");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("c5fcc029-774d-498f-b894-fdd4cfec0d68"));

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "TotalRooms",
                table: "Properties");

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
    }
}
