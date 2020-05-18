using Microsoft.EntityFrameworkCore.Migrations;

namespace NatureStoreWebApp.Migrations
{
    public partial class Manytomany4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductDisease",
                columns: table => new
                {
                    Id_product = table.Column<int>(nullable: false),
                    Id_disease = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDisease", x => new { x.Id_product, x.Id_disease });
                    table.ForeignKey(
                        name: "FK_ProductDisease_Diseases_Id_disease",
                        column: x => x.Id_disease,
                        principalTable: "Diseases",
                        principalColumn: "Id_disease",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDisease_Products_Id_product",
                        column: x => x.Id_product,
                        principalTable: "Products",
                        principalColumn: "Id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDisease_Id_disease",
                table: "ProductDisease",
                column: "Id_disease");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDisease");
        }
    }
}
