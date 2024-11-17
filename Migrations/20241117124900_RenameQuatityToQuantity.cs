using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class RenameQuatityToQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quatity",
                table: "Products",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Quatity");
        }
    }
}
