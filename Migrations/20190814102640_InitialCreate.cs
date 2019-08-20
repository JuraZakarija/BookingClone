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
                    RoomNumber = table.Column<string>(maxLength: 5, nullable: false),
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
                    { 1, 15.00m, new DateTime(2019, 8, 14, 10, 26, 40, 425, DateTimeKind.Utc).AddTicks(6523), false, "Todoric", null },
                    { 2, 20.00m, new DateTime(2019, 8, 14, 10, 26, 40, 425, DateTimeKind.Utc).AddTicks(7478), false, "Airbnb", null },
                    { 3, 23.00m, new DateTime(2019, 8, 14, 10, 26, 40, 425, DateTimeKind.Utc).AddTicks(7489), false, "Booking", null },
                    { 4, 17.50m, new DateTime(2019, 8, 14, 10, 26, 40, 425, DateTimeKind.Utc).AddTicks(7490), false, "Trivago", null }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "Birthdate", "CreatedAt", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 428, DateTimeKind.Utc).AddTicks(2825), "radekoncar@gmail.com", "Rade", "M", false, "Končar", "0917453456", null },
                    { 2, new DateTime(1982, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 428, DateTimeKind.Utc).AddTicks(7628), "antemastelic@gmail.com", "Ante", "M", false, "Mastelić", "0924567484", null },
                    { 3, new DateTime(1991, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 428, DateTimeKind.Utc).AddTicks(7669), "miadimsic@hotmail.com", "Mia", "F", false, "Dimšić", "0959375035", null },
                    { 4, new DateTime(1982, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 428, DateTimeKind.Utc).AddTicks(7675), "hrvojehorvat@hotmail.com", "Hrvoje", "M", false, "Horvat", "0983765905", null }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CreatedAt", "IsDeleted", "Name", "PhoneNumber", "UpdatedAt", "WebAddress" },
                values: new object[,]
                {
                    { 1, "Ulica Izidora Kršnjavog 1", new DateTime(2019, 8, 14, 10, 26, 40, 426, DateTimeKind.Utc).AddTicks(1924), false, "Westin", "38514892000", null, "www.westinzagreb.com" },
                    { 2, "Miramarska Cesta 24", new DateTime(2019, 8, 14, 10, 26, 40, 426, DateTimeKind.Utc).AddTicks(2910), false, "International", "38516108800", null, "www.hotel-international.hr" },
                    { 3, "Trg Krešimira Ćosića 9", new DateTime(2019, 8, 14, 10, 26, 40, 426, DateTimeKind.Utc).AddTicks(2924), false, "Esplanade", "38514566600", null, "www.esplanade.hr" },
                    { 4, "Trg Josipa Jurja Strossmayera 10", new DateTime(2019, 8, 14, 10, 26, 40, 426, DateTimeKind.Utc).AddTicks(2925), false, "Palace", "38514899600", null, "www.palace.hr" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AgencyId", "CreatedAt", "GuestId", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(6540), 1, false, null },
                    { 2, 2, new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(7131), 2, false, null },
                    { 3, 3, new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(7140), 3, false, null },
                    { 4, 4, new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(7164), 4, false, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedAt", "HotelId", "IsDeleted", "NumberOfBeds", "PricePerNight", "RoomNumber", "Size", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(5989), 1, false, 2, 100.00m, "101", 34.42m, "Double", null },
                    { 5, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7681), 1, false, 2, 100.00m, "102", 34.42m, "Double", null },
                    { 9, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7685), 1, false, 2, 100.00m, "103", 34.42m, "Double", null },
                    { 2, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7659), 2, false, 2, 200.00m, "202", 42.12m, "Suite", null },
                    { 6, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7682), 2, false, 2, 200.00m, "204", 42.12m, "Suite", null },
                    { 10, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7687), 2, false, 2, 200.00m, "206", 42.12m, "Suite", null },
                    { 3, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7679), 3, false, 4, 300.00m, "301", 54.66m, "Quad", null },
                    { 7, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7683), 3, false, 4, 300.00m, "304", 54.66m, "Quad", null },
                    { 11, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7688), 3, false, 4, 300.00m, "305", 54.66m, "Quad", null },
                    { 4, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7680), 4, false, 4, 400.00m, "202", 73.81m, "Executive", null },
                    { 8, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7684), 4, false, 4, 400.00m, "206", 73.81m, "Executive", null },
                    { 12, new DateTime(2019, 8, 14, 10, 26, 40, 427, DateTimeKind.Utc).AddTicks(7689), 4, false, 4, 400.00m, "208", 73.81m, "Executive", null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AgencyId", "CheckIn", "CheckOut", "CreatedAt", "GuestId", "IsDeleted", "PaymentId", "RoomId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(2005), 1, false, null, 1, null },
                    { 2, 2, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(3333), 2, false, null, 2, null },
                    { 3, 3, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(3366), 3, false, null, 3, null },
                    { 4, 4, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 14, 10, 26, 40, 429, DateTimeKind.Utc).AddTicks(3374), 4, false, null, 4, null }
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
