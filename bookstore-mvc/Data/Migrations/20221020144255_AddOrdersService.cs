using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookstore_mvc.Data.Migrations
{
    public partial class AddOrdersService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nameof(UserId)",
                table: "Orders",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_nameof(UserId)",
                table: "Orders",
                column: "nameof(UserId)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_nameof(UserId)",
                table: "Orders",
                column: "nameof(UserId)",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_nameof(UserId)",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_nameof(UserId)",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "nameof(UserId)",
                table: "Orders");
        }
    }
}
