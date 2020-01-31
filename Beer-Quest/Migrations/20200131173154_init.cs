using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
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
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brewery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    CheersCount = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    BreweryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AlcoholPercent = table.Column<double>(nullable: false),
                    DrinkTypeId = table.Column<int>(nullable: false),
                    BreweryId = table.Column<int>(nullable: false),
                    HouseFav = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drink_Brewery_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Brewery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Birthday", "FirstName", "LastName", "Phone", "UserTypeId" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "e05773ae-afa9-4c35-a21f-a69c658dde27", "ApplicationUser", null, true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEItDqxT0F9G6wpEPplUY0rbtpeqsejU2oynZualaZYuGIkqB5Qkt/H8fM+Cuphar7g==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com", "04-29-1997", "admin", "admin", "(989)464-5890", 1 });

            migrationBuilder.InsertData(
                table: "Brewery",
                columns: new[] { "Id", "Address", "CheersCount", "City", "Name", "Phone", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 1, null, 0, "Nashville", "Tennessee Brew Works", "(615)436-0050", "00000000-ffff-ffff-ffff-ffffffffffff", 37203 },
                    { 2, null, 0, "Nashville", "Czans", "(615)748-1399", "00000000-ffff-ffff-ffff-ffffffffffff", 37203 },
                    { 3, null, 0, "Nashville", "Yee Haw", "(615)647-8272", "00000000-ffff-ffff-ffff-ffffffffffff", 37203 },
                    { 4, null, 0, "Nashville", "Jackalope", "(615) 873-4313", "00000000-ffff-ffff-ffff-ffffffffffff", 37203 }
                });

            migrationBuilder.InsertData(
                table: "DrinkType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 15, "Dark Wheat" },
                    { 16, "Pale Ale" },
                    { 17, "Blonde Ale" },
                    { 18, "IPA" },
                    { 19, "American Pale Ale" },
                    { 21, "Dark Lager" },
                    { 14, "Stout" },
                    { 22, "Maple Brown Ale" },
                    { 23, "Bohemian Pilsner" },
                    { 24, "Red Rye Ale" },
                    { 20, "Scottish Style Ale" },
                    { 13, "Session India Pale Ale" },
                    { 11, "English-Style Mild Ale" },
                    { 10, "Hazy Pale Ale" },
                    { 9, "Saison / Farmhouse Ale" },
                    { 8, "Key Lime Hazy India Pale Ale" },
                    { 7, "Tenn Whisky Barrel-Aged English Strong Ale" },
                    { 6, "Imperial Stout" },
                    { 5, "Imperial India Pale Ale" },
                    { 4, "English-Style Pub Ale" },
                    { 3, "Belgian-Style White/Witbier" },
                    { 2, "India Pale Ale" },
                    { 1, "American Blonde Ale" },
                    { 12, "American Session Porter" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "UserTypeName" },
                values: new object[,]
                {
                    { 2, "Brew Admin" },
                    { 1, "Admin" },
                    { 3, "Non-Admin" }
                });

            migrationBuilder.InsertData(
                table: "Drink",
                columns: new[] { "Id", "AlcoholPercent", "BreweryId", "DrinkTypeId", "HouseFav", "Name" },
                values: new object[,]
                {
                    { 1, 4.5, 1, 1, true, "State Park Blonde" },
                    { 27, 4.7999999999999998, 4, 23, false, "Sarka" },
                    { 26, 5.0, 4, 22, true, "Bearwalker" },
                    { 25, 5.5, 4, 19, false, "Thunder Ann" },
                    { 24, 6.7000000000000002, 3, 18, false, "IPA" },
                    { 23, 5.5, 3, 21, true, "Dunkel" },
                    { 22, 5.0, 3, 20, false, "Eighty" },
                    { 21, 5.7000000000000002, 3, 19, false, "Pale Ale" },
                    { 20, 6.2000000000000002, 2, 18, false, "Czann's IPA" },
                    { 19, 5.25, 2, 16, false, "Czann's Pale Ale" },
                    { 18, 4.25, 2, 17, false, "Czann's Blonde" },
                    { 17, 5.5, 2, 4, false, "Czann’s Dunkelweizen" },
                    { 16, 6.2000000000000002, 2, 4, false, "Czann's Oatmeal Stout" },
                    { 28, 5.5999999999999996, 4, 23, false, "Rompo Red Rye" },
                    { 15, 4.2000000000000002, 1, 13, false, "Session IPA" },
                    { 13, 4.5, 1, 11, false, "Mild Davis" },
                    { 12, 5.4000000000000004, 1, 10, false, "Hopped and Devoted" },
                    { 11, 8.0, 1, 9, false, "Basil Ryeman" },
                    { 10, 5.0, 1, 8, false, "Key of Lime" },
                    { 9, 8.5, 1, 7, false, "Old Burton Extra (OBE)" },
                    { 8, 10.0, 1, 6, false, "Colts Bolts" },
                    { 7, 10.0, 1, 5, false, "Secret City Imperial IPA" },
                    { 6, 6.0, 1, 2, false, "Cutaway Rye IPA" },
                    { 5, 5.25, 1, 4, false, "Extra Easy Ale" },
                    { 4, 7.5, 1, 2, false, "1927 IPA" },
                    { 3, 5.0999999999999996, 1, 3, false, "Southern Wit" },
                    { 2, 6.0, 1, 2, true, "Hippies and Cowboys" },
                    { 14, 4.9000000000000004, 1, 12, false, "Pie Town Session Porter" },
                    { 29, 7.2000000000000002, 4, 2, false, "Fennario" }
                });

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
                name: "IX_Drink_BreweryId",
                table: "Drink",
                column: "BreweryId");
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
                name: "Cheer");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "DrinkType");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Brewery");
        }
    }
}
