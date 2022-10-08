using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore_mvc.Data.Migrations
{
    public partial class RenameAuthorFullNameToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Authors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "FullName");
        }
    }
}
