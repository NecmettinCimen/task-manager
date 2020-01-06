using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class worklabelsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Labels",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    Name = table.Column<string>(maxLength: 250)
                },
                constraints: table => { table.PrimaryKey("PK_Labels", x => x.Id); });

            migrationBuilder.CreateTable(
                "WorkLabels",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    WorkId = table.Column<int>(),
                    LabelId = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_WorkLabels", x => x.Id); });

            migrationBuilder.InsertData(
                "Labels",
                new[] {"Id", "CreateDate", "CreatorId", "Name", "Status"},
                new object[] {1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Web", (short) 1});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Labels");

            migrationBuilder.DropTable(
                "WorkLabels");
        }
    }
}