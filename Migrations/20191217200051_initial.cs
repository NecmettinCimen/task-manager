using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Events",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    Name = table.Column<string>(maxLength: 250)
                },
                constraints: table => { table.PrimaryKey("PK_Events", x => x.Id); });

            migrationBuilder.CreateTable(
                "Projects",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    Title = table.Column<string>(maxLength: 250),
                    Explanation = table.Column<string>(maxLength: 1000, nullable: true),
                    ManagerId = table.Column<int>(),
                    EventId = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Projects", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    NameSurname = table.Column<string>(maxLength: 100),
                    Email = table.Column<string>(maxLength: 150),
                    Password = table.Column<string>(maxLength: 150)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "WorkHistorys",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    PrevStatus = table.Column<short>(),
                    WorkId = table.Column<int>(),
                    ManagerId = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_WorkHistorys", x => x.Id); });

            migrationBuilder.CreateTable(
                "Works",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<short>(),
                    CreateDate = table.Column<DateTime>(),
                    CreatorId = table.Column<int>(),
                    Title = table.Column<string>(maxLength: 250),
                    Explanation = table.Column<string>(maxLength: 1000, nullable: true),
                    ProjectId = table.Column<int>(),
                    ManagerId = table.Column<int>(),
                    EventId = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_Works", x => x.Id); });

            migrationBuilder.InsertData(
                "Events",
                new[] {"Id", "CreateDate", "CreatorId", "Name", "Status"},
                new object[,]
                {
                    {1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bekliyor", (short) 1},
                    {2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "İşlemde", (short) 1},
                    {3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tamamlandı", (short) 1},
                    {4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Red Edildi", (short) 1}
                });

            migrationBuilder.InsertData(
                "Users",
                new[] {"Id", "CreateDate", "CreatorId", "Email", "NameSurname", "Password", "Status"},
                new object[]
                {
                    1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin", "Admin", "1",
                    (short) 1
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Events");

            migrationBuilder.DropTable(
                "Projects");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "WorkHistorys");

            migrationBuilder.DropTable(
                "Works");
        }
    }
}