using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class baseentitypublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Works",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "WorkLabels",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "WorkHistorys",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Users",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Projects",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Labels",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Public",
                table: "Events",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "Public",
                value: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Public",
                value: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Public",
                value: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Public",
                value: true);

            migrationBuilder.UpdateData(
                table: "Labels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Public",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Public",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Public",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "WorkLabels");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "WorkHistorys");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "Public",
                table: "Events");
        }
    }
}
