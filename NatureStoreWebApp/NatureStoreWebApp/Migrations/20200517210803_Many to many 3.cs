using Microsoft.EntityFrameworkCore.Migrations;

namespace NatureStoreWebApp.Migrations
{
    public partial class Manytomany3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductIngredient",
                columns: table => new
                {
                    Id_product = table.Column<int>(nullable: false),
                    Id_ingredient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductIngredient", x => new { x.Id_product, x.Id_ingredient });
                    table.ForeignKey(
                        name: "FK_ProductIngredient_Ingredients_Id_ingredient",
                        column: x => x.Id_ingredient,
                        principalTable: "Ingredients",
                        principalColumn: "Id_ingredient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductIngredient_Products_Id_product",
                        column: x => x.Id_product,
                        principalTable: "Products",
                        principalColumn: "Id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductIngredient_Id_ingredient",
                table: "ProductIngredient",
                column: "Id_ingredient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductIngredient");
        }
    }
}
