using Microsoft.EntityFrameworkCore.Migrations;

namespace IStore.Database.Migrations
{
    public partial class isFeaturedInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFeatured",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFeatured",
                table: "Categories");
        }
    }
}
