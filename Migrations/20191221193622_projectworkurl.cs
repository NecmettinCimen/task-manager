using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class projectworkurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Works",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Works",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Projects",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Works",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
