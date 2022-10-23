using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore_mvc.Data.Migrations
{
    public partial class ChangePublisherInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Publishers",
                newName: "About");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "About",
                table: "Publishers",
                newName: "Biography");
        }
    }
}
