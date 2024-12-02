using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSelectedToProductCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Thêm cột IsSelected vào bảng Product_carts
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",  // Tên cột mới
                table: "Product_carts",  // Bảng mà cột sẽ được thêm vào
                type: "bit",  // Kiểu dữ liệu của cột (bit cho true/false)
                nullable: false,  // Không cho phép giá trị null
                defaultValue: false);  // Giá trị mặc định là false
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Xóa cột IsSelected nếu cần rollback migration
            migrationBuilder.DropColumn(
                name: "IsSelected",  // Tên cột cần xóa
                table: "Product_carts");  // Bảng chứa cột cần xóa
        }
    }
}
