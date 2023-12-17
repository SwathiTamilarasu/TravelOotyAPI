using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class PropertyAmenitiesLinkChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Amenities_AmenitiesId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AmenitiesId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("489c65d4-2a23-4383-9793-210690cf85ac"));

            migrationBuilder.DropColumn(
                name: "AmenitiesId",
                table: "Properties");

            migrationBuilder.CreateTable(
                name: "PropertyAmenitiesLinks",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAmenitiesLinks", x => new { x.AmenitiesId, x.PropertyID });
                    table.ForeignKey(
                        name: "FK_PropertyAmenitiesLinks_Amenities_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenities",
                        principalColumn: "AmenitiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyAmenitiesLinks_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAmenitiesLinks_PropertyID",
                table: "PropertyAmenitiesLinks",
                column: "PropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyAmenitiesLinks");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("06d2447d-9a19-42f8-8bed-9f548d438cf2"));

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(9422), new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(9426) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(902), new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(906) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("489c65d4-2a23-4383-9793-210690cf85ac"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(7200), new DateTime(2022, 2, 18, 2, 20, 52, 136, DateTimeKind.Utc).AddTicks(8004) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(2039), new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(2043) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(3566), new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(3569) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(4721), new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(4724) });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AmenitiesId",
                table: "Properties",
                column: "AmenitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Amenities_AmenitiesId",
                table: "Properties",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "AmenitiesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
