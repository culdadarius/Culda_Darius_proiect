using Microsoft.EntityFrameworkCore.Migrations;

namespace Culda_Darius_Proiect.Migrations
{
    public partial class DrinkCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Drink",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrinkCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DrinkCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrinkCategory_Drink_DrinkID",
                        column: x => x.DrinkID,
                        principalTable: "Drink",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_StoreID",
                table: "Drink",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkCategory_CategoryID",
                table: "DrinkCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_DrinkCategory_DrinkID",
                table: "DrinkCategory",
                column: "DrinkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Store_StoreID",
                table: "Drink",
                column: "StoreID",
                principalTable: "Store",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Store_StoreID",
                table: "Drink");

            migrationBuilder.DropTable(
                name: "DrinkCategory");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Drink_StoreID",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Drink");
        }
    }
}
