using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class ProdUpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("d43f457e-efae-4ffd-90a3-ac0d18bb7824"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(1869), new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(3483), new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(3487) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("36a811f7-6dc2-416d-a963-c8c7ea069ba1"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 23, 6, 50, 7, 688, DateTimeKind.Utc).AddTicks(9044), new DateTime(2022, 9, 23, 6, 50, 7, 688, DateTimeKind.Utc).AddTicks(9883) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(4599), new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(4602) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(5546), new DateTime(2022, 9, 23, 6, 50, 7, 689, DateTimeKind.Utc).AddTicks(5549) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("36a811f7-6dc2-416d-a963-c8c7ea069ba1"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(7376), new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(8741), new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(8746) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("d43f457e-efae-4ffd-90a3-ac0d18bb7824"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(4549), new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(5548) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(9917), new DateTime(2022, 9, 18, 3, 51, 19, 21, DateTimeKind.Utc).AddTicks(9921) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 3, 51, 19, 22, DateTimeKind.Utc).AddTicks(1073), new DateTime(2022, 9, 18, 3, 51, 19, 22, DateTimeKind.Utc).AddTicks(1077) });
        }
    }
}
