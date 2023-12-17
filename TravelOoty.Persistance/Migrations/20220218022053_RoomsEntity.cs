using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class RoomsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("c5fcc029-774d-498f-b894-fdd4cfec0d68"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "PropertyID",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegularPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomsCategory_RoomCategoryId",
                        column: x => x.RoomCategoryId,
                        principalTable: "RoomsCategory",
                        principalColumn: "RoomCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFacilityLink",
                columns: table => new
                {
                    RoomFacilityId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacilityLink", x => new { x.RoomFacilityId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_RoomFacilityLink_RoomFacility_RoomFacilityId",
                        column: x => x.RoomFacilityId,
                        principalTable: "RoomFacility",
                        principalColumn: "RoomFacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFacilityLink_Rooms_RoomId",
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

            //migrationBuilder.InsertData(
            //    table: "Rooms",
            //    columns: new[] { "RoomId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", 
            //        "Name", "PropertyID", "RegularPrice", "RoomCategoryId", "SpecialPrice" },
            //    values: new object[] { 1, null, new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(3566), null, new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(3569),
            //        "Big Boss", 2, "5000", 2, "3000" });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(4721), new DateTime(2022, 2, 18, 2, 20, 52, 137, DateTimeKind.Utc).AddTicks(4724) });

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilityLink_RoomId",
                table: "RoomFacilityLink",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PropertyID",
                table: "Rooms",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCategoryId",
                table: "Rooms",
                column: "RoomCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomFacilityLink");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("489c65d4-2a23-4383-9793-210690cf85ac"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(7307), new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(9230), new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(9234) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("c5fcc029-774d-498f-b894-fdd4cfec0d68"), "Shaaniya" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "Address", "AmenitiesId", "CreatedBy", "CreatedDate", "ImageName", "ImagePath", "LastModifiedBy", "LastModifiedDate", "Location", "Name", "PackageName", "PostalCode", "PropertierName", "PropertyTypeId", "TotalRooms" },
                values: new object[] { 1, "Coimbatore", 1, null, new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(7553), null, null, null, new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(7556), "Coimbatore II", "Shanniya Estate", "Family", null, "Shanniya", 1, 0 });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(4043), new DateTime(2022, 2, 2, 14, 21, 16, 968, DateTimeKind.Utc).AddTicks(5189) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(1432), new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(1437) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(3003), new DateTime(2022, 2, 2, 14, 21, 16, 969, DateTimeKind.Utc).AddTicks(3007) });
        }
    }
}
