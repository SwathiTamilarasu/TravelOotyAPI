using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class bookingAddAduitEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("bd213927-ad1e-42c4-979f-8e931d5a32fd"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RoomBookingLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomBookingLink",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "RoomBookingLink",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "RoomBookingLink",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(4015), new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(5221), new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(5225) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("99b3a655-4a57-4285-bef1-56140457a651"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(944), new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(6512), new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(6516) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(7772), new DateTime(2022, 8, 13, 2, 2, 14, 263, DateTimeKind.Utc).AddTicks(7775) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("99b3a655-4a57-4285-bef1-56140457a651"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RoomBookingLink");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RoomBookingLink");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "RoomBookingLink");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "RoomBookingLink");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(7162), new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(7166) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(8501), new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("bd213927-ad1e-42c4-979f-8e931d5a32fd"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(3571), new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(9741), new DateTime(2022, 8, 9, 16, 51, 42, 87, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 9, 16, 51, 42, 88, DateTimeKind.Utc).AddTicks(976), new DateTime(2022, 8, 9, 16, 51, 42, 88, DateTimeKind.Utc).AddTicks(979) });
        }
    }
}
