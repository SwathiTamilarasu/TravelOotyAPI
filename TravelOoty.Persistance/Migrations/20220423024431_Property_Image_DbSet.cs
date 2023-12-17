using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class Property_Image_DbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("a762f7b0-2cb4-4198-9a89-9694aeb72e17"));

            migrationBuilder.CreateTable(
                name: "PropertiesImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertiesImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(6170), new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(8181), new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("5c02ea3a-3d63-4bc2-9581-95deff72cd63"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(1840), new DateTime(2022, 4, 23, 2, 44, 30, 877, DateTimeKind.Utc).AddTicks(3414) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(60), new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(2024), new DateTime(2022, 4, 23, 2, 44, 30, 878, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesImages_PropertyId",
                table: "PropertiesImages",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertiesImages");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("5c02ea3a-3d63-4bc2-9581-95deff72cd63"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(7852), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(7856) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(8892), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(8894) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("a762f7b0-2cb4-4198-9a89-9694aeb72e17"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(5025), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(6233) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(9864), new DateTime(2022, 3, 8, 10, 9, 22, 258, DateTimeKind.Utc).AddTicks(9866) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 10, 9, 22, 259, DateTimeKind.Utc).AddTicks(821), new DateTime(2022, 3, 8, 10, 9, 22, 259, DateTimeKind.Utc).AddTicks(824) });
        }
    }
}
