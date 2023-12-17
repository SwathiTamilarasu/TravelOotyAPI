using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomsRoomId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomsRoomId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a9484448-21a2-4bab-a4f1-96254a98788b"));

            migrationBuilder.DropColumn(
                name: "RoomsRoomId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(7852), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(7856) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(8892), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(8894) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a762f7b0-2cb4-4198-9a89-9694aeb72e17"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(5025), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(9864), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(9866) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 259, DateTimeKind.Utc).AddTicks(821), new DateTime(2022, 3, 8, 10, 9, 22, 259, DateTimeKind.Utc).AddTicks(824) });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Bookings_Rooms_RoomId",
            //    table: "Bookings");

            //migrationBuilder.DropIndex(
            //    name: "IX_Bookings_RoomId",
            //    table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a762f7b0-2cb4-4198-9a89-9694aeb72e17"));

            migrationBuilder.AddColumn<int>(
                name: "RoomsRoomId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(6357), new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(6360) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(7439), new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(7442) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a9484448-21a2-4bab-a4f1-96254a98788b"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(3564), new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(4836) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(8487), new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(9543), new DateTime(2022, 3, 7, 17, 5, 20, 879, DateTimeKind.Utc).AddTicks(9546) });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomsRoomId",
                table: "Bookings",
                column: "RoomsRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomsRoomId",
                table: "Bookings",
                column: "RoomsRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
