using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class RenameQuantityInProductBillAndProductCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quatity",
                table: "Product_bills",
                newName: "UserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "Product_carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Product_billProductBillId",
                table: "Product_carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Product_bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_carts_Product_billProductBillId",
                table: "Product_carts",
                column: "Product_billProductBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_carts_ProductId",
                table: "Product_carts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_carts_Product_bills_Product_billProductBillId",
                table: "Product_carts",
                column: "Product_billProductBillId",
                principalTable: "Product_bills",
                principalColumn: "ProductBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_carts_Products_ProductId",
                table: "Product_carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_carts_Product_bills_Product_billProductBillId",
                table: "Product_carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_carts_Products_ProductId",
                table: "Product_carts");

            migrationBuilder.DropIndex(
                name: "IX_Product_carts_Product_billProductBillId",
                table: "Product_carts");

            migrationBuilder.DropIndex(
                name: "IX_Product_carts_ProductId",
                table: "Product_carts");

            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "Product_carts");

            migrationBuilder.DropColumn(
                name: "Product_billProductBillId",
                table: "Product_carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product_bills");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Product_bills",
                newName: "Quatity");
        }
    }
}
