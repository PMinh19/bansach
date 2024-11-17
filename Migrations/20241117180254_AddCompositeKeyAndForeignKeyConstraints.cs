using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeKeyAndForeignKeyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tạo khóa chính kết hợp cho bảng Product_carts
            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_carts",
                table: "Product_carts",
                columns: new[] { "UserId", "ProductId" });

            // Thêm khóa ngoại cho ProductId trong bảng Product_carts tham chiếu đến bảng Products
            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Product",
                table: "Product_carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);  // Xóa giỏ hàng nếu sản phẩm bị xóa

            // Thêm khóa ngoại cho UserId trong bảng Product_carts tham chiếu đến bảng Users
            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_User",
                table: "Product_carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);  // Xóa giỏ hàng nếu người dùng bị xóa
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa khóa ngoại và khóa chính nếu rollback migration
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Product",
                table: "Product_carts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_User",
                table: "Product_carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_carts",
                table: "Product_carts");
        }
    }
}
