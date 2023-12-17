using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class AddedCityProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("06d2447d-9a19-42f8-8bed-9f548d438cf2"));

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 23, 17, 47, 22, 470, DateTimeKind.Utc).AddTicks(9478), new DateTime(2022, 2, 23, 17, 47, 22, 470, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, null, new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(2591), null, new DateTime(2022, 2, 23, 17, 47, 22, 471, DateTimeKind.Utc).AddTicks(2593), "Ooty" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                column: "CityId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Properties_Cities_CityId",
            //    table: "Properties",
            //    column: "CityId",
            //    principalTable: "Cities",
            //    principalColumn: "CityId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Properties_Cities_CityId",
            //    table: "Properties");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Properties_CityId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("158ba658-af02-452d-bd4d-3bdb82c94108"));

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(3627), new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(3631) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(4694), new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(4697) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("06d2447d-9a19-42f8-8bed-9f548d438cf2"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(475), new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(1632) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(5713), new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(5716) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(7238), new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(7241) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(8903), new DateTime(2022, 2, 22, 15, 46, 57, 366, DateTimeKind.Utc).AddTicks(8907) });
        }
    }
}
