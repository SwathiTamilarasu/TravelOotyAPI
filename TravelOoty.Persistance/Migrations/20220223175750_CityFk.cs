using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class CityFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("158ba658-af02-452d-bd4d-3bdb82c94108"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(3040), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(3044) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(7133), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(4900), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(4909) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("aaaf4d7a-f956-42a3-b7cd-64abe40589b0"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 492, DateTimeKind.Utc).AddTicks(9938), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(6087), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(6089) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(9230), new DateTime(2022, 2, 23, 17, 57, 49, 493, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 57, 49, 494, DateTimeKind.Utc).AddTicks(979), new DateTime(2022, 2, 23, 17, 57, 49, 494, DateTimeKind.Utc).AddTicks(986) });


            //migrationBuilder.CreateIndex(
            //    name: "IX_Properties_CityId",
            //    table: "Properties",
            //    column: "CityId");

        //    migrationBuilder.AddForeignKey(
        //  name: "FK_Properties_Cities_CityId",
        //  table: "Properties",
        //  column: "CityId",
        //  principalTable: "Cities",
        //  principalColumn: "CityId",
        //  onDelete: ReferentialAction.Cascade);
       }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Properties_Cities_CityId",
            //    table: "Properties");


            //migrationBuilder.DropIndex(
            //    name: "IX_Properties_CityId",
            //    table: "Properties");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("aaaf4d7a-f956-42a3-b7cd-64abe40589b0"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 470, DateTimeKind.Utc).AddTicks(9478), new DateTime(2022, 2, 23, 17, 47, 22, 470, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(2591), new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(2593) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(565), new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(568) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("158ba658-af02-452d-bd4d-3bdb82c94108"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 470, DateTimeKind.Utc).AddTicks(6971), new DateTime(2022, 2, 23, 17, 47, 22, 470, DateTimeKind.Utc).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(1589), new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(1592) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(4629), new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(6061), new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(6064) });
        }
    }
}
