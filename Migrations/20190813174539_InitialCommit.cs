using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingClone.Migrations
{
    public partial class InitialCommit : Migration
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
                    Commission = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
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
                    AgencyId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PricePerNight = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
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
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    PaymentId = table.Column<int>(nullable: true)
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
                    { 1, 15.00m, new DateTime(2019, 8, 13, 17, 45, 38, 773, DateTimeKind.Utc).AddTicks(9158), false, "Todoric", null },
                    { 2, 20.00m, new DateTime(2019, 8, 13, 17, 45, 38, 775, DateTimeKind.Utc).AddTicks(270), false, "Airbnb", null },
                    { 3, 23.00m, new DateTime(2019, 8, 13, 17, 45, 38, 775, DateTimeKind.Utc).AddTicks(293), false, "Booking", null },
                    { 4, 17.50m, new DateTime(2019, 8, 13, 17, 45, 38, 775, DateTimeKind.Utc).AddTicks(294), false, "Trivago", null }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Birthdate", "CreatedAt", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 778, DateTimeKind.Utc).AddTicks(7079), "radekoncar@gmail.com", "Rade", "M", false, "Končar", "0917453456", null },
                    { 2, new DateTime(1982, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 782, DateTimeKind.Utc).AddTicks(9014), "antemastelic@gmail.com", "Ante", "M", false, "Mastelić", "0924567484", null },
                    { 3, new DateTime(1991, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 782, DateTimeKind.Utc).AddTicks(9150), "miadimsic@hotmail.com", "Mia", "F", false, "Dimšić", "0959375035", null },
                    { 4, new DateTime(1982, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 782, DateTimeKind.Utc).AddTicks(9166), "hrvojehorvat@hotmail.com", "Hrvoje", "M", false, "Horvat", "0983765905", null }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CreatedAt", "IsDeleted", "Name", "PhoneNumber", "UpdatedAt", "WebAddress" },
                values: new object[,]
                {
                    { 1, "Ulica Izidora Kršnjavog 1", new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(1792), false, "Westin", "38514892000", null, "www.westinzagreb.com" },
                    { 2, "Miramarska Cesta 24", new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(3703), false, "International", "38516108800", null, "www.hotel-international.hr" },
                    { 3, "Trg Krešimira Ćosića 9", new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(3729), false, "Esplanade", "38514566600", null, "www.esplanade.hr" },
                    { 4, "Trg Josipa Jurja Strossmayera 10", new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(3730), false, "Palace", "38514899600", null, "www.palace.hr" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AgencyId", "CreatedAt", "GuestId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(1876), 1, false, null },
                    { 2, 2, new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(3193), 2, false, null },
                    { 3, 3, new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(3218), 3, false, null },
                    { 4, 4, new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(3223), 4, false, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedAt", "HotelId", "IsDeleted", "NumberOfBeds", "PricePerNight", "Size", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(4419), 1, false, 2, 100.00m, 34.42m, "Double", null },
                    { 2, new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(7156), 2, false, 2, 200.00m, 42.12m, "Suite", null },
                    { 3, new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(7190), 3, false, 4, 300.00m, 54.66m, "Quad", null },
                    { 4, new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(7192), 4, false, 4, 400.00m, 73.81m, "Executive", null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AgencyId", "CheckIn", "CheckOut", "CreatedAt", "GuestId", "IsDeleted", "PaymentId", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(384), 1, false, null, 1, null },
                    { 2, 2, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(3478), 2, false, null, 2, null },
                    { 3, 3, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(3562), 3, false, null, 3, null },
                    { 4, 4, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(3578), 4, false, null, 4, null }
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
                name: "IX_Payments_AgencyId",
                table: "Payments",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GuestId",
                table: "Payments",
                column: "GuestId");

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
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
