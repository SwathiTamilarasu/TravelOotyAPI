using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class promocode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("719dde98-e73c-4880-95b6-2a197b714e44"));

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(6457), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7047), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7049) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a4db8f7c-06d7-4b1b-b0dd-248491d5efe9"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(5031), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(5595) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7603), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(8145), new DateTime(2023, 4, 2, 11, 34, 46, 216, DateTimeKind.Utc).AddTicks(8146) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a4db8f7c-06d7-4b1b-b0dd-248491d5efe9"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(4837), new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(4839) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(5470), new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(5471) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("719dde98-e73c-4880-95b6-2a197b714e44"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(3421), new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(3971) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(6029), new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(6031) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(6573), new DateTime(2022, 11, 10, 14, 28, 12, 215, DateTimeKind.Utc).AddTicks(6575) });
        }
    }
}
