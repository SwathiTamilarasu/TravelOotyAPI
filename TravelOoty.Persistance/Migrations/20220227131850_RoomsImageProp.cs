using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomsImageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("9ec16b8e-8ab0-4d94-8b47-3b25acee7b23"));

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Rooms");

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(9880), new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(9885) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(1368), new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(1373) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("bece35a0-6a33-450d-a296-87b4d69c21a1"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(7445), new DateTime(2022, 2, 27, 13, 18, 49, 235, DateTimeKind.Utc).AddTicks(8338) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(3472), new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(5420), new DateTime(2022, 2, 27, 13, 18, 49, 236, DateTimeKind.Utc).AddTicks(5424) });

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("bece35a0-6a33-450d-a296-87b4d69c21a1"));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(7312), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(8392), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("9ec16b8e-8ab0-4d94-8b47-3b25acee7b23"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(4809), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(9452), new DateTime(2022, 2, 27, 8, 27, 8, 871, DateTimeKind.Utc).AddTicks(9455) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 27, 8, 27, 8, 872, DateTimeKind.Utc).AddTicks(509), new DateTime(2022, 2, 27, 8, 27, 8, 872, DateTimeKind.Utc).AddTicks(513) });
        }
    }
}
