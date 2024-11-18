using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    public partial class AddPaymentStatusToProductBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Product_bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Chưa thanh toán");  // Cập nhật giá trị mặc định
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Product_bills");
        }
    }
}
