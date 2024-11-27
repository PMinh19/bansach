using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswererEmailToQNA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswererEmail",
                table: "QNA",
                type: "nvarchar(max)",
                nullable: true); // Chỉnh sửa thành nullable: true

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "QNA",
                type: "nvarchar(max)",
                nullable: true); // Chỉnh sửa thành nullable: true
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswererEmail",
                table: "QNA");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "QNA");
        }
    }

}
