using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class intialTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("36a811f7-6dc2-416d-a963-c8c7ea069ba1"));

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Properties",
                type: "real",
                nullable: false,
                defaultValue: 0f);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("635ae1f0-08bc-4ac4-a7bc-254f9c96782e"));

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Properties");

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
    }
}
