using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingClone.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    WebAddress = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Margin = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    HotelId = table.Column<int>(nullable: false),
                    Size = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    NumberOfBeds = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    PricePerNight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AgencyId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "Commission", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 15.00m, new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(1839), false, "Todoric", null },
                    { 2, 20.00m, new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(2636), false, "Airbnb", null },
                    { 3, 23.00m, new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(2645), false, "Booking", null },
                    { 4, 17.50m, new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(2646), false, "Trivago", null }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Birthdate", "CreatedAt", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(6967), null, "Rade", "M", false, "Končar", null, null },
                    { 2, null, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(7775), null, "Ante", "M", false, "Mastelić", null, null },
                    { 3, null, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(7784), null, "Mia", "F", false, "Dimšić", null, null },
                    { 4, null, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(7784), null, "Hrvoje", "M", false, "Horvat", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CreatedAt", "IsDeleted", "Name", "PhoneNumber", "UpdatedAt", "WebAddress" },
                values: new object[,]
                {
                    { 1, "Ulica Izidora Kršnjavog 1", new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(7234), false, "Westin", "38514892000", null, "www.westinzagreb.com" },
                    { 2, "Miramarska Cesta 24", new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(8198), false, "International", "38516108800", null, "www.hotel-international.hr" },
                    { 3, "Trg Krešimira Ćosića 9", new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(8210), false, "Esplanade", "38514566600", null, "www.esplanade.hr" },
                    { 4, "Trg Josipa Jurja Strossmayera 10", new DateTime(2019, 8, 10, 23, 14, 22, 459, DateTimeKind.Utc).AddTicks(8211), false, "Palace", "38514899600", null, "www.palace.hr" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Margin", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(9576), false, 25.00m, null },
                    { 2, new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(9905), false, 40.00m, null },
                    { 3, new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(9909), false, 20.00m, null },
                    { 4, new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(9910), false, 35.00m, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedAt", "HotelId", "IsDeleted", "NumberOfBeds", "PricePerNight", "Size", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(2771), 1, false, 2, 100.00m, 34.42m, "Double", null },
                    { 2, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(4102), 2, false, 2, 200.00m, 42.12m, "Suite", null },
                    { 3, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(4116), 3, false, 4, 300.00m, 54.66m, "Quad", null },
                    { 4, new DateTime(2019, 8, 10, 23, 14, 22, 460, DateTimeKind.Utc).AddTicks(4117), 4, false, 4, 400.00m, 73.81m, "Executive", null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AgencyId", "CheckIn", "CheckOut", "CreatedAt", "GuestId", "IsDeleted", "PaymentId", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(1854), 1, false, 1, 1, null },
                    { 2, 2, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(6034), 2, false, 2, 2, null },
                    { 3, 3, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(6067), 3, false, 3, 3, null },
                    { 4, 4, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 10, 23, 14, 22, 461, DateTimeKind.Utc).AddTicks(6073), 4, false, 4, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_Name",
                table: "Agencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AgencyId",
                table: "Bookings",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestId",
                table: "Bookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PaymentId",
                table: "Bookings",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_LastName",
                table: "Guests",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_Name",
                table: "Hotels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
