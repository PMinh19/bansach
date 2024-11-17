using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class RenameCartIdToUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Xóa primary key cũ
            migrationBuilder.DropPrimaryKey(name: "PK_Product_carts", table: "Product_carts");

            // Xóa cột CartId
            migrationBuilder.DropColumn(name: "CartId", table: "Product_carts");

            // Thêm cột UserId
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Product_carts",
                nullable: false,
                defaultValue: 0);

            // Thêm primary key mới dựa trên UserId và ProductId
            migrationBuilder.AddPrimaryKey(name: "PK_Product_carts", table: "Product_carts", columns: new[] { "UserId", "ProductId" });

            // Nếu cần, tạo chỉ mục cho UserId và ProductId
            migrationBuilder.CreateIndex(
                name: "IX_Product_carts_UserId_ProductId",
                table: "Product_carts",
                columns: new[] { "UserId", "ProductId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Quay lại thay đổi, xóa cột UserId và khôi phục cột CartId
            migrationBuilder.DropPrimaryKey(name: "PK_Product_carts", table: "Product_carts");

            migrationBuilder.DropColumn(name: "UserId", table: "Product_carts");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Product_carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(name: "PK_Product_carts", table: "Product_carts", column: "CartId");
        }
    }

}
