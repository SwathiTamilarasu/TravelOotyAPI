using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoombookingEntityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("99b3a655-4a57-4285-bef1-56140457a651"));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "RoomBookingLink",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(3582), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(3586) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(4577), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(4580) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("486d1bce-f80e-4bac-907c-e4abce28da5b"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(1356), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(5589), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(6507), new DateTime(2022, 8, 14, 7, 20, 43, 332, DateTimeKind.Utc).AddTicks(6510) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("486d1bce-f80e-4bac-907c-e4abce28da5b"));

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "RoomBookingLink");

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
    }
}
