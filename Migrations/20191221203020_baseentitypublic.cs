using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class baseentitypublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                "Public",
                "Works",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                "Public",
                "WorkLabels",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                "Public",
                "WorkHistorys",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                "Public",
                "Users",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                "Public",
                "Projects",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                "Public",
                "Labels",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                "Public",
                "Events",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                "Events",
                "Id",
                1,
                "Public",
                true);

            migrationBuilder.UpdateData(
                "Events",
                "Id",
                2,
                "Public",
                true);

            migrationBuilder.UpdateData(
                "Events",
                "Id",
                3,
                "Public",
                true);

            migrationBuilder.UpdateData(
                "Events",
                "Id",
                4,
                "Public",
                true);

            migrationBuilder.UpdateData(
                "Labels",
                "Id",
                1,
                "Public",
                true);

            migrationBuilder.UpdateData(
                "Users",
                "Id",
                1,
                "Public",
                true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Public",
                "Works");

            migrationBuilder.DropColumn(
                "Public",
                "WorkLabels");

            migrationBuilder.DropColumn(
                "Public",
                "WorkHistorys");

            migrationBuilder.DropColumn(
                "Public",
                "Users");

            migrationBuilder.DropColumn(
                "Public",
                "Projects");

            migrationBuilder.DropColumn(
                "Public",
                "Labels");

            migrationBuilder.DropColumn(
                "Public",
                "Events");
        }
    }
}