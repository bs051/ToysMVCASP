using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToysMVCASP.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    ForGender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ToyStore",
                columns: table => new
                {
                    ToyStoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreNAme = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    OpeningTime = table.Column<DateTime>(nullable: false),
                    ClosingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyStore", x => x.ToyStoreId);
                });

            migrationBuilder.CreateTable(
                name: "Toy",
                columns: table => new
                {
                    ToyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToyName = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AgeGroup = table.Column<int>(nullable: false),
                    ToyRating = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toy", x => x.ToyId);
                    table.ForeignKey(
                        name: "FK_Toy_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToyRel",
                columns: table => new
                {
                    ToyRelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InStock = table.Column<bool>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    ToyId = table.Column<int>(nullable: false),
                    ToyStoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToyRel", x => x.ToyRelId);
                    table.ForeignKey(
                        name: "FK_ToyRel_Toy_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toy",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToyRel_ToyStore_ToyStoreId",
                        column: x => x.ToyStoreId,
                        principalTable: "ToyStore",
                        principalColumn: "ToyStoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toy_CategoryID",
                table: "Toy",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ToyRel_ToyId",
                table: "ToyRel",
                column: "ToyId");

            migrationBuilder.CreateIndex(
                name: "IX_ToyRel_ToyStoreId",
                table: "ToyRel",
                column: "ToyStoreId");

            var sqlFile = Path.Combine(".\\Database", @"script.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToyRel");

            migrationBuilder.DropTable(
                name: "Toy");

            migrationBuilder.DropTable(
                name: "ToyStore");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
