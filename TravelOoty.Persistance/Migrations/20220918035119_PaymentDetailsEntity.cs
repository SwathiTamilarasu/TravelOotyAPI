using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelOoty.Persistance.Migrations
{
    public partial class PaymentDetailsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("5ec892be-0da2-4094-94d3-54f9224885c8"));

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentDetailsId);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_BookingId",
                table: "PaymentDetails",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: new Guid("d43f457e-efae-4ffd-90a3-ac0d18bb7824"));

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenitiesId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(6983), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(6987) });

            migrationBuilder.UpdateData(
                table: "HotelCategory",
                keyColumn: "HotelCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(7967), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Name" },
                values: new object[] { new Guid("5ec892be-0da2-4094-94d3-54f9224885c8"), "Shaaniya" });

            migrationBuilder.UpdateData(
                table: "PropertyTypes",
                keyColumn: "PropertyTypeId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(4961), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(5690) });

            migrationBuilder.UpdateData(
                table: "RoomFacility",
                keyColumn: "RoomFacilityId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(8874), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(8877) });

            migrationBuilder.UpdateData(
                table: "RoomsCategory",
                keyColumn: "RoomCategoryId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(9743), new DateTime(2022, 9, 18, 2, 38, 0, 913, DateTimeKind.Utc).AddTicks(9746) });
        }
    }
}
