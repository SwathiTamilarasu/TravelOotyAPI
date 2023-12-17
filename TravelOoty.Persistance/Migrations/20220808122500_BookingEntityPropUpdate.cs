using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class BookingEntityPropUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("ff69fa50-49e8-4d41-9834-c4dd9baebdde"));

            //migrationBuilder.AlterColumn<int>(
            //    name: "RoomId",
            //    table: "Rooms",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalTime",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmEmailId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBookingExpired",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequest",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(4192), new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(4196) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(5194), new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(5198) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("e7858b82-f9c6-4488-9953-1fb2f67f3920"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(1936), new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(6152), new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(6154) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(7094), new DateTime(2022, 8, 8, 12, 24, 59, 508, DateTimeKind.Utc).AddTicks(7096) });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Rooms_Bookings_RoomId",
            //    table: "Rooms",
            //    column: "RoomId",
            //    principalTable: "Bookings",
            //    principalColumn: "BookingId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_RoomId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("e7858b82-f9c6-4488-9953-1fb2f67f3920"));

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ConfirmEmailId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsBookingExpired",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SpecialRequest",
                table: "Bookings");

            //migrationBuilder.AlterColumn<int>(
            //    name: "RoomId",
            //    table: "Rooms",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(5145), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(6714), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("ff69fa50-49e8-4d41-9834-c4dd9baebdde"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(2280), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(7961), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(7964) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(8980), new DateTime(2022, 7, 3, 4, 2, 36, 374, DateTimeKind.Utc).AddTicks(8983) });

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
    }
}
