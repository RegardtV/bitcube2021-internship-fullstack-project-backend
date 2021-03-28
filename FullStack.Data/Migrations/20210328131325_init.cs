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
                    AdminRole = table.Column<bool>(type: "bit", nullable: false)
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
                    { 10, "Paarl", 5 },
                    { 8, "Pietermaritzburg", 4 },
                    { 7, "Durban", 4 },
                    { 6, "Soweto", 3 },
                    { 9, "Cape Town", 5 },
                    { 4, "Bethlehem", 2 },
                    { 3, "Bloemfontein", 2 },
                    { 2, "Port Elizabeth", 1 },
                    { 5, "Johannesburg", 3 }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Eastern Cape" },
                    { 2, "Free State" },
                    { 3, "Gauteng" },
                    { 4, "KwaZulu-Natal" },
                    { 5, "Western Cape" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdminRole", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, true, "properproperties@gmail.com", "John", "Smit", "ppAdmin1", null },
                    { 1, false, "regardtvisagie@gmail.com", "Regardt", "Visagie", "Reg14061465", null }
                });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CityId", "Date", "Description", "Featured", "Header", "Price", "ProvinceId", "State", "UserId" },
                values: new object[] { 1, 10, new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cozy and luxurious apartment ideal for newlyweds", true, "2 Bedroom Luxury Apartment", 1320000m, 5, "Live", 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CityId", "Date", "Description", "Featured", "Header", "Price", "ProvinceId", "State", "UserId" },
                values: new object[] { 2, 3, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Has a big living room and nice view of the city...", false, "Large family house that sleeps 6", 2000000m, 2, "Live", 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "CityId", "Date", "Description", "Featured", "Header", "Price", "ProvinceId", "State", "UserId" },
                values: new object[] { 3, 6, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "King Louis IV used to live here", false, "Mansion fit for a king", 11450000m, 3, "Hidden", 1 });

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
