using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullMart.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatineAppUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_Users_UserId",
                schema: "Security",
                table: "UserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserToken",
                schema: "Security",
                table: "UserToken");

            migrationBuilder.RenameTable(
                name: "UserToken",
                schema: "Security",
                newName: "RefreshTokens",
                newSchema: "Security");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "Security",
                table: "RefreshTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                schema: "Security",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.AppUserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "Security",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "Security",
                table: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RefreshToken",
                schema: "Security");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshTokens",
                schema: "Security",
                table: "RefreshTokens");

            migrationBuilder.RenameTable(
                name: "RefreshTokens",
                schema: "Security",
                newName: "UserToken",
                newSchema: "Security");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserToken",
                schema: "Security",
                table: "UserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_Users_UserId",
                schema: "Security",
                table: "UserToken",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
