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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
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
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    UserId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "Commission", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 15.00m, new DateTime(2019, 8, 28, 9, 24, 11, 538, DateTimeKind.Utc).AddTicks(9748), false, "Todoric", null },
                    { 2, 20.00m, new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(594), false, "Airbnb", null },
                    { 3, 23.00m, new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(603), false, "Booking", null },
                    { 4, 17.50m, new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(604), false, "Trivago", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1987, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ff369b55-53e4-409f-80a8-9bc3253c2133", "radekoncar@gmail.com", false, "Rade", "M", "Končar", false, null, null, null, "AQAAAAEAACcQAAAAEKpWL+mTkRIKPkqPjoHlMayEDAhsILHpdb45yUXnTeCUMcx2Evzj6si4FmKAGJtk/g==", "0917453456", false, null, false, null },
                    { 2, 0, new DateTime(1982, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "f4c93c7c-7b10-4aff-99b5-b332cade23ba", "antemastelic@gmail.com", false, "Ante", "M", "Mastelić", false, null, null, null, null, "0924567484", false, null, false, null },
                    { 3, 0, new DateTime(1991, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "3a28d468-52bd-4609-a8db-24229c3b2f08", "miadimsic@hotmail.com", false, "Mia", "F", "Dimšić", false, null, null, null, null, "0959375035", false, null, false, null },
                    { 4, 0, new DateTime(1982, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "486bf39a-4fb0-4038-9b0d-2692910ed85e", "hrvojehorvat@hotmail.com", false, "Hrvoje", "M", "Horvat", false, null, null, null, null, "0983765905", false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CreatedAt", "IsDeleted", "Name", "PhoneNumber", "UpdatedAt", "WebAddress" },
                values: new object[,]
                {
                    { 1, "Ulica Izidora Kršnjavog 1", new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(6790), false, "Westin", "38514892000", null, "www.westinzagreb.com" },
                    { 2, "Miramarska Cesta 24", new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(8815), false, "International", "38516108800", null, "www.hotel-international.hr" },
                    { 3, "Trg Krešimira Ćosića 9", new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(8843), false, "Esplanade", "38514566600", null, "www.esplanade.hr" },
                    { 4, "Trg Josipa Jurja Strossmayera 10", new DateTime(2019, 8, 28, 9, 24, 11, 539, DateTimeKind.Utc).AddTicks(8844), false, "Palace", "38514899600", null, "www.palace.hr" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AgencyId", "CreatedAt", "IsDeleted", "Price", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 8, 28, 9, 24, 11, 561, DateTimeKind.Utc).AddTicks(2761), false, 0m, null, 1 },
                    { 2, 2, new DateTime(2019, 8, 28, 9, 24, 11, 561, DateTimeKind.Utc).AddTicks(3866), false, 0m, null, 2 },
                    { 3, 3, new DateTime(2019, 8, 28, 9, 24, 11, 561, DateTimeKind.Utc).AddTicks(3876), false, 0m, null, 3 },
                    { 4, 4, new DateTime(2019, 8, 28, 9, 24, 11, 561, DateTimeKind.Utc).AddTicks(3877), false, 0m, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "CreatedAt", "HotelId", "IsDeleted", "NumberOfBeds", "PricePerNight", "RoomNumber", "Size", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 8, 28, 9, 24, 11, 541, DateTimeKind.Utc).AddTicks(9977), 1, false, 2, 100.00m, "101", 34.42m, "Double", null },
                    { 5, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1652), 1, false, 2, 100.00m, "102", 33.77m, "Double", null },
                    { 9, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1656), 1, false, 2, 100.00m, "103", 43.46m, "Double", null },
                    { 2, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1630), 2, false, 2, 200.00m, "202", 42.12m, "Suite", null },
                    { 6, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1653), 2, false, 2, 200.00m, "204", 36.46m, "Suite", null },
                    { 10, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1657), 2, false, 2, 200.00m, "206", 34.64m, "Suite", null },
                    { 3, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1649), 3, false, 4, 300.00m, "301", 54.66m, "Quad", null },
                    { 7, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1654), 3, false, 4, 300.00m, "304", 65.45m, "Quad", null },
                    { 11, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1704), 3, false, 4, 300.00m, "305", 53.66m, "Quad", null },
                    { 4, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1651), 4, false, 4, 400.00m, "202", 73.81m, "Executive", null },
                    { 8, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1655), 4, false, 4, 400.00m, "206", 75.64m, "Executive", null },
                    { 12, new DateTime(2019, 8, 28, 9, 24, 11, 542, DateTimeKind.Utc).AddTicks(1705), 4, false, 4, 400.00m, "208", 79.45m, "Executive", null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "AgencyId", "CheckIn", "CheckOut", "CreatedAt", "IsDeleted", "PaymentId", "RoomId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 28, 9, 24, 11, 560, DateTimeKind.Utc).AddTicks(4166), false, null, 1, null, 1 },
                    { 2, 2, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 28, 9, 24, 11, 560, DateTimeKind.Utc).AddTicks(6592), false, null, 2, null, 2 },
                    { 3, 3, new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 28, 9, 24, 11, 560, DateTimeKind.Utc).AddTicks(6638), false, null, 3, null, 3 },
                    { 4, 4, new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 28, 9, 24, 11, 560, DateTimeKind.Utc).AddTicks(6648), false, null, 4, null, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_Name",
                table: "Agencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LastName",
                table: "AspNetUsers",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AgencyId",
                table: "Bookings",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PaymentId",
                table: "Bookings",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

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
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
