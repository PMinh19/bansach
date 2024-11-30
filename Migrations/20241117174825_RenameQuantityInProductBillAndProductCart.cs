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
            // Đổi tên cột "Quatity" thành "UserId" trong bảng Product_bills
            migrationBuilder.RenameColumn(
                name: "Quatity",
                table: "Product_bills",
                newName: "UserId");

            // Thêm cột "IsCheckedOut" vào bảng Product_carts
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedOut",
                table: "Product_carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            // Thêm cột "Product_billProductBillId" vào bảng Product_carts
            migrationBuilder.AddColumn<int>(
                name: "Product_billProductBillId",
                table: "Product_carts",
                type: "int",
                nullable: true);

            // Thêm cột "Quantity" vào bảng Product_bills
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Product_bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Đổi tên cột "Quantity" thành "CartQuantity" trong bảng Product_carts
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Product_carts",
                newName: "CartQuantity");

            // Tạo chỉ mục cho các cột liên quan trong bảng Product_carts
            migrationBuilder.CreateIndex(
                name: "IX_Product_carts_Product_billProductBillId",
                table: "Product_carts",
                column: "Product_billProductBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_carts_ProductId",
                table: "Product_carts",
                column: "ProductId");

            // Thêm khóa ngoại cho bảng Product_carts
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
            // Xóa khóa ngoại và chỉ mục khi rollback
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

            // Xóa các cột đã thêm
            migrationBuilder.DropColumn(
                name: "IsCheckedOut",
                table: "Product_carts");

            migrationBuilder.DropColumn(
                name: "Product_billProductBillId",
                table: "Product_carts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Product_bills");

            // Đổi lại tên cột "UserId" thành "Quatity" trong bảng Product_bills
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Product_bills",
                newName: "Quatity");

            // Đổi lại tên cột "CartQuantity" thành "Quantity" trong bảng Product_carts
            migrationBuilder.RenameColumn(
                name: "CartQuantity",
                table: "Product_carts",
                newName: "Quantity");
        }
    }
}
