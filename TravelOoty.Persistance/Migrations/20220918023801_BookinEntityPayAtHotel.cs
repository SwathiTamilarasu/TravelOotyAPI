using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class BookinEntityPayAtHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("76fd4191-0743-4bdf-92e5-1d7c36085c98"));

            migrationBuilder.AddColumn<bool>(
                name: "PayAtHotel",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(6983), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(6987) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(7967), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("5ec892be-0da2-4094-94d3-54f9224885c8"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(4961), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(5690) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(8874), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(9743), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(9746) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("5ec892be-0da2-4094-94d3-54f9224885c8"));

            migrationBuilder.DropColumn(
                name: "PayAtHotel",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 23, 17, 10, 21, 719, DateTimeKind.Utc).AddTicks(3735), new DateTime(2022, 8, 23, 17, 10, 21, 719, DateTimeKind.Utc).AddTicks(3755) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 23, 17, 10, 21, 719, DateTimeKind.Utc).AddTicks(6873), new DateTime(2022, 8, 23, 17, 10, 21, 719, DateTimeKind.Utc).AddTicks(6894) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("76fd4191-0743-4bdf-92e5-1d7c36085c98"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 23, 17, 10, 21, 718, DateTimeKind.Utc).AddTicks(453), new DateTime(2022, 8, 23, 17, 10, 21, 718, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 23, 17, 10, 21, 719, DateTimeKind.Utc).AddTicks(9186), new DateTime(2022, 8, 23, 17, 10, 21, 719, DateTimeKind.Utc).AddTicks(9198) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 23, 17, 10, 21, 720, DateTimeKind.Utc).AddTicks(843), new DateTime(2022, 8, 23, 17, 10, 21, 720, DateTimeKind.Utc).AddTicks(848) });
        }
    }
}
