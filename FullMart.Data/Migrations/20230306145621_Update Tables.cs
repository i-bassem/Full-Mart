using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullMart.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WishLists_WishListId",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WishListId",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WishListId",
                schema: "Security",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "WishLists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_AppUserId",
                table: "WishLists",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Users_AppUserId",
                table: "WishLists",
                column: "AppUserId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Users_AppUserId",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_AppUserId",
                table: "WishLists");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "WishLists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "WishListId",
                schema: "Security",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_WishListId",
                schema: "Security",
                table: "Users",
                column: "WishListId",
                unique: true,
                filter: "[WishListId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WishLists_WishListId",
                schema: "Security",
                table: "Users",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "Id");
        }
    }
}
