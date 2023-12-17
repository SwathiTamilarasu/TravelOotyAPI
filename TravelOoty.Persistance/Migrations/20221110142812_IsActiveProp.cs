using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class IsActiveProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("635ae1f0-08bc-4ac4-a7bc-254f9c96782e"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("719dde98-e73c-4880-95b6-2a197b714e44"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Properties");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 29, 5, 49, 7, 750, DateTimeKind.Utc).AddTicks(7847), new DateTime(2022, 10, 29, 5, 49, 7, 750, DateTimeKind.Utc).AddTicks(7849) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 29, 5, 49, 7, 750, DateTimeKind.Utc).AddTicks(8773), new DateTime(2022, 10, 29, 5, 49, 7, 750, DateTimeKind.Utc).AddTicks(8775) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("635ae1f0-08bc-4ac4-a7bc-254f9c96782e"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 29, 5, 49, 7, 750, DateTimeKind.Utc).AddTicks(5813), new DateTime(2022, 10, 29, 5, 49, 7, 750, DateTimeKind.Utc).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 29, 5, 49, 7, 751, DateTimeKind.Utc).AddTicks(3451), new DateTime(2022, 10, 29, 5, 49, 7, 751, DateTimeKind.Utc).AddTicks(3459) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 29, 5, 49, 7, 751, DateTimeKind.Utc).AddTicks(4598), new DateTime(2022, 10, 29, 5, 49, 7, 751, DateTimeKind.Utc).AddTicks(4606) });
        }
    }
}
