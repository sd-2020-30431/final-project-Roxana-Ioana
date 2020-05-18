using Microsoft.EntityFrameworkCore.Migrations;

namespace NatureStoreWebApp.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_category",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_category",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
