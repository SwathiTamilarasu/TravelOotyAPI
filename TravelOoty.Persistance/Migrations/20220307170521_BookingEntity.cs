using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class BookingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("2e014494-0f86-417e-8749-095b2c36609c"));

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "RoomImages");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomsRoomId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a9484448-21a2-4bab-a4f1-96254a98788b"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "RoomImages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(6100), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(7519), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("2e014494-0f86-417e-8749-095b2c36609c"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(2638), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(9022), new DateTime(2022, 2, 27, 13, 33, 48, 160, DateTimeKind.Utc).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 33, 48, 161, DateTimeKind.Utc).AddTicks(182), new DateTime(2022, 2, 27, 13, 33, 48, 161, DateTimeKind.Utc).AddTicks(185) });
        }
    }
}
