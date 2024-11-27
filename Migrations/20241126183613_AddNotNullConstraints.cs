using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanSach.Migrations
{
    /// <inheritdoc />
    public partial class AddNotNullConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QNA",
                nullable: false,
                defaultValue: "No answer provided",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswererEmail",
                table: "QNA",
                nullable: false,
                defaultValue: "No email provided",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "QNA",
                nullable: false,
                defaultValue: "No email provided",
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QNA",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "AnswererEmail",
                table: "QNA",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "QNA",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: false);
        }
    }

}
