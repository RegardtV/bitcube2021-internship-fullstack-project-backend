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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adverts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "Eastern Cape" },
                    { 2, "Free State" },
                    { 3, "Gauteng" },
                    { 4, "KwaZulu-Natal" },
                    { 5, "Western Cape" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "regardtvisagie@gmail.com", "Regardt", "Visagie", "Reg14061465" });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "City", "Date", "Description", "Header", "Price", "Province", "State", "UserId" },
                values: new object[] { 1, "Paarl", new DateTime(2020, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cozy and luxurious apartment ideal for newlyweds", "2 Bedroom Luxury Apartment", 1320000m, "Western Cape", "Live", 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "City", "Date", "Description", "Header", "Price", "Province", "State", "UserId" },
                values: new object[] { 2, "Bloemfontein", new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Has a big living room and nice view of the city dsfasdfasdfasdfasdfasdfasdfasdf dfasdfasdfasdfasdf adsfasdfasdfasdf", "Large family house that sleeps 6", 1450000m, "Free State", "Hidden", 1 });

            migrationBuilder.InsertData(
                table: "Adverts",
                columns: new[] { "Id", "City", "Date", "Description", "Header", "Price", "Province", "State", "UserId" },
                values: new object[] { 3, "Johannesburg", new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Has a big living room and nice view of the city dsfasdfasdfasdfasdfasdfasdfasdf dfasdfasdfasdfasdf adsfasdfasdfasdf", "Large family house that sleeps 6", 1450000m, "Gauteng", "Hidden", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_UserId",
                table: "Adverts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
