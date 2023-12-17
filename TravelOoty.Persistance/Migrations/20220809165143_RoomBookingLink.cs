using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomBookingLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Rooms_Bookings_RoomId",
            //    table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("e7858b82-f9c6-4488-9953-1fb2f67f3920"));

            //migrationBuilder.DropColumn(
            //    name: "RoomId",
            //    table: "Bookings");

            //migrationBuilder.AlterColumn<int>(
            //    name: "RoomId",
            //    table: "Rooms",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "RoomBookingLink",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBookingLink", x => new { x.BookingId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomBookingLink_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomBookingLink_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookingLink_RoomId",
                table: "RoomBookingLink",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomBookingLink");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("bd213927-ad1e-42c4-979f-8e931d5a32fd"));

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Rooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_RoomId",
                table: "Rooms",
                column: "RoomId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
