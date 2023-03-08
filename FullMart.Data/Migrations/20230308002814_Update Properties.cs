using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullMart.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_BrandCategories_BrandCategoryId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BrandCategories_BrandCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProducts_OrderProductsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CartProducts_CartProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_OrderProductsId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WishListProducts_WishListProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_WishListProducts_WishListProductId",
                table: "WishLists");

            migrationBuilder.AlterColumn<int>(
                name: "WishListProductId",
                table: "WishLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WishListProductId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderProductsId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CartProductId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderProductsId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandCategoryId",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandCategoryId",
                table: "Brands",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_BrandCategories_BrandCategoryId",
                table: "Brands",
                column: "BrandCategoryId",
                principalTable: "BrandCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BrandCategories_BrandCategoryId",
                table: "Categories",
                column: "BrandCategoryId",
                principalTable: "BrandCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderProducts_OrderProductsId",
                table: "Orders",
                column: "OrderProductsId",
                principalTable: "OrderProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CartProducts_CartProductId",
                table: "Products",
                column: "CartProductId",
                principalTable: "CartProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_OrderProductsId",
                table: "Products",
                column: "OrderProductsId",
                principalTable: "OrderProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WishListProducts_WishListProductId",
                table: "Products",
                column: "WishListProductId",
                principalTable: "WishListProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_WishListProducts_WishListProductId",
                table: "WishLists",
                column: "WishListProductId",
                principalTable: "WishListProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_BrandCategories_BrandCategoryId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BrandCategories_BrandCategoryId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderProducts_OrderProductsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_CartProducts_CartProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderProducts_OrderProductsId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_WishListProducts_WishListProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_WishListProducts_WishListProductId",
                table: "WishLists");

            migrationBuilder.AlterColumn<int>(
                name: "WishListProductId",
                table: "WishLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WishListProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderProductsId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderProductsId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandCategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandCategoryId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_BrandCategories_BrandCategoryId",
                table: "Brands",
                column: "BrandCategoryId",
                principalTable: "BrandCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BrandCategories_BrandCategoryId",
                table: "Categories",
                column: "BrandCategoryId",
                principalTable: "BrandCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderProducts_OrderProductsId",
                table: "Orders",
                column: "OrderProductsId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CartProducts_CartProductId",
                table: "Products",
                column: "CartProductId",
                principalTable: "CartProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderProducts_OrderProductsId",
                table: "Products",
                column: "OrderProductsId",
                principalTable: "OrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_WishListProducts_WishListProductId",
                table: "Products",
                column: "WishListProductId",
                principalTable: "WishListProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_WishListProducts_WishListProductId",
                table: "WishLists",
                column: "WishListProductId",
                principalTable: "WishListProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
