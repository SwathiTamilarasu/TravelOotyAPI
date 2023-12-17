using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class bookingEntityUpdateBlock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingLink_Bookings_BookingId",
                table: "RoomBookingLink");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingLink_Rooms_RoomId",
                table: "RoomBookingLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookingLink",
                table: "RoomBookingLink");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a3876732-28f0-4b3f-843a-bdbcb7374802"));

            migrationBuilder.RenameTable(
                name: "RoomBookingLink",
                newName: "RoomBookingLinks");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingLink_RoomId",
                table: "RoomBookingLinks",
                newName: "IX_RoomBookingLinks_RoomId");

            migrationBuilder.AddColumn<bool>(
                name: "isBlocked",
                table: "Bookings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookingLinks",
                table: "RoomBookingLinks",
                columns: new[] { "BookingId", "RoomId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingLinks_Bookings_BookingId",
                table: "RoomBookingLinks",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingLinks_Rooms_RoomId",
                table: "RoomBookingLinks",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
               // onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingLinks_Bookings_BookingId",
                table: "RoomBookingLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingLinks_Rooms_RoomId",
                table: "RoomBookingLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookingLinks",
                table: "RoomBookingLinks");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("76fd4191-0743-4bdf-92e5-1d7c36085c98"));

            migrationBuilder.DropColumn(
                name: "isBlocked",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "RoomBookingLinks",
                newName: "RoomBookingLink");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingLinks_RoomId",
                table: "RoomBookingLink",
                newName: "IX_RoomBookingLink_RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookingLink",
                table: "RoomBookingLink",
                columns: new[] { "BookingId", "RoomId" });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(5541), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(5545) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(6605), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(6608) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a3876732-28f0-4b3f-843a-bdbcb7374802"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(1798), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(3371) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(7981), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(7987) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(9745), new DateTime(2022, 8, 20, 18, 52, 35, 74, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingLink_Bookings_BookingId",
                table: "RoomBookingLink",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingLink_Rooms_RoomId",
                table: "RoomBookingLink",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
