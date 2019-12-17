using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class eventfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Projects",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Events",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreateDate", "CreatorId", "Name", "Status" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Oluşturuldu.", (short)1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Projects",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Events",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
