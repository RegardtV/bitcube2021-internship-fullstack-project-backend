using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminRole = table.Column<bool>(type: "bit", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteJoin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdvertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteJoin", x => new { x.UserId, x.AdvertId });
                    table.ForeignKey(
                        name: "FK_FavouriteJoin_Adverts_AdvertId",
                        column: x => x.AdvertId,
                        principalTable: "Adverts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavouriteJoin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "East London", 1 },
                    { 2, "Port Elizabeth", 1 },
                    { 3, "Bloemfontein", 2 },
                    { 4, "Bethlehem", 2 },
                    { 5, "Johannesburg", 3 },
                    { 6, "Soweto", 3 },
                    { 7, "Durban", 4 },
                    { 8, "Pietermaritzburg", 4 },
                    { 9, "Cape Town", 5 },
                    { 10, "Paarl", 5 }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Western Cape" },
                    { 4, "KwaZulu-Natal" },
                    { 1, "Eastern Cape" },
                    { 2, "Free State" },
                    { 3, "Gauteng" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdminRole", "Email", "FirstName", "LastName", "Locked", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 5, false, "pieterj@yhotmail.com", "Pieter", "Joubert", false, "Jouba1987", null },
                    { 2, true, "properproperties1@gmail.com", "John", "Smith", false, "ppAdmin1", null },
                    { 3, true, "properproperties2@gmail.com", "Johan", "Smit", false, "ppAdmin2", null },
                    { 1, false, "regardtvisagie@gmail.com", "Regardt", "Visagie", false, "Reg14061465", null },
                    { 4, false, "mk@yahoo.com", "Michelle", "Koorts", false, "Koorts123", null },
                    { 6, false, "cs@ymail.com", "Chulu", "Sibuzo", false, "Chulu1982", null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CityId", "Date", "Description", "Featured", "Header", "Price", "ProvinceId", "State", "UserId" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cozy and luxurious apartment ideal for newlyweds", true, "2 Bedroom Luxury Apartment", 1320000m, 5, "Live", 1 },
                    { 2, 3, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Has a big living room and nice view of the city...", false, "Large family house that sleeps 6", 2000000m, 2, "Live", 1 },
                    { 3, 6, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "King Louis IV used to live here", false, "Mansion fit for a king", 11450000m, 3, "Hidden", 1 },
                    { 4, 9, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Also includes a big garden for those who love gardening", true, "Double story, 5 bedroom house with granny flat", 4500000m, 5, "Live", 4 },
                    { 5, 2, new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Situated in up-market area overlooking the city", false, "Bachelor plat ideal for students", 900000m, 1, "Live", 5 },
                    { 6, 2, new DateTime(2020, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recently repainted", true, "2 bedroom, 2 bathroom duplex", 1050000m, 1, "Live", 5 },
                    { 7, 7, new DateTime(2020, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Set in one of the most secure, private and exclusive estates in Uzili Upper. High Uzili is a sought-after Security Estate of 19 architecturally designed homes with the emphasis on security, style and peace and boasts natural Fynbos gardens and private walkways.", true, "4 Bedroom House for Sale in Uzuli", 5600000m, 4, "Live", 6 },
                    { 8, 3, new DateTime(2020, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "This Face Brick property consists of the following: 2 Bedrooms equipped with built-in cupboards and carpets, 2 Bathroom an Open-plan lounge, dining room, and a kitchen. A private garden in a very neat condition. Double Hollywood garage.", false, "2 Bedroom Town House for sale in Langenhovenpark", 860000m, 2, "Live", 6 },
                    { 9, 3, new DateTime(2020, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious 205 sq and such a neat unit and complex near doctors, church and shopping center. Lots of space inside and so many cupboards. Tandem garage! Call now!!!!", false, "3 Bedroom Townhouse for Sale in Pellissier", 1249000m, 2, "Hidden", 6 },
                    { 10, 5, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attention all young couples looking for an amazing start-up home. This beautiful two-bedroom one bathroom unit is perfect for a small family looking to settle. Situated near all major amenities you cannot ask for more, from good schools to better shopping centers this location has it all.", false, "2 Bedroom Townhouse for Sale in Groenboom", 1000000m, 3, "Live", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteJoin_AdvertId",
                table: "FavouriteJoin",
                column: "AdvertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteJoin");

            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
