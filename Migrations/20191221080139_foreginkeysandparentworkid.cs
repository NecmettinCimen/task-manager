using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class foreginkeysandparentworkid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "ParentWorkId",
                "Works",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Works_CreatorId",
                "Works",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_Works_EventId",
                "Works",
                "EventId");

            migrationBuilder.CreateIndex(
                "IX_Works_ManagerId",
                "Works",
                "ManagerId");

            migrationBuilder.CreateIndex(
                "IX_Works_ParentWorkId",
                "Works",
                "ParentWorkId");

            migrationBuilder.CreateIndex(
                "IX_Works_ProjectId",
                "Works",
                "ProjectId");

            migrationBuilder.CreateIndex(
                "IX_WorkLabels_CreatorId",
                "WorkLabels",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_WorkLabels_LabelId",
                "WorkLabels",
                "LabelId");

            migrationBuilder.CreateIndex(
                "IX_WorkLabels_WorkId",
                "WorkLabels",
                "WorkId");

            migrationBuilder.CreateIndex(
                "IX_WorkHistorys_CreatorId",
                "WorkHistorys",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_WorkHistorys_ManagerId",
                "WorkHistorys",
                "ManagerId");

            migrationBuilder.CreateIndex(
                "IX_WorkHistorys_WorkId",
                "WorkHistorys",
                "WorkId");

            migrationBuilder.CreateIndex(
                "IX_Users_CreatorId",
                "Users",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_Projects_CreatorId",
                "Projects",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_Projects_EventId",
                "Projects",
                "EventId");

            migrationBuilder.CreateIndex(
                "IX_Projects_ManagerId",
                "Projects",
                "ManagerId");

            migrationBuilder.CreateIndex(
                "IX_Labels_CreatorId",
                "Labels",
                "CreatorId");

            migrationBuilder.CreateIndex(
                "IX_Events_CreatorId",
                "Events",
                "CreatorId");

            migrationBuilder.AddForeignKey(
                "FK_Events_Users_CreatorId",
                "Events",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Labels_Users_CreatorId",
                "Labels",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Projects_Users_CreatorId",
                "Projects",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Projects_Events_EventId",
                "Projects",
                "EventId",
                "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Projects_Users_ManagerId",
                "Projects",
                "ManagerId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Users_Users_CreatorId",
                "Users",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_WorkHistorys_Users_CreatorId",
                "WorkHistorys",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_WorkHistorys_Users_ManagerId",
                "WorkHistorys",
                "ManagerId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_WorkHistorys_Works_WorkId",
                "WorkHistorys",
                "WorkId",
                "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_WorkLabels_Users_CreatorId",
                "WorkLabels",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_WorkLabels_Labels_LabelId",
                "WorkLabels",
                "LabelId",
                "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_WorkLabels_Works_WorkId",
                "WorkLabels",
                "WorkId",
                "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                "FK_Works_Users_CreatorId",
                "Works",
                "CreatorId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Works_Events_EventId",
                "Works",
                "EventId",
                "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Works_Users_ManagerId",
                "Works",
                "ManagerId",
                "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Works_Works_ParentWorkId",
                "Works",
                "ParentWorkId",
                "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                "FK_Works_Projects_ProjectId",
                "Works",
                "ProjectId",
                "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Events_Users_CreatorId",
                "Events");

            migrationBuilder.DropForeignKey(
                "FK_Labels_Users_CreatorId",
                "Labels");

            migrationBuilder.DropForeignKey(
                "FK_Projects_Users_CreatorId",
                "Projects");

            migrationBuilder.DropForeignKey(
                "FK_Projects_Events_EventId",
                "Projects");

            migrationBuilder.DropForeignKey(
                "FK_Projects_Users_ManagerId",
                "Projects");

            migrationBuilder.DropForeignKey(
                "FK_Users_Users_CreatorId",
                "Users");

            migrationBuilder.DropForeignKey(
                "FK_WorkHistorys_Users_CreatorId",
                "WorkHistorys");

            migrationBuilder.DropForeignKey(
                "FK_WorkHistorys_Users_ManagerId",
                "WorkHistorys");

            migrationBuilder.DropForeignKey(
                "FK_WorkHistorys_Works_WorkId",
                "WorkHistorys");

            migrationBuilder.DropForeignKey(
                "FK_WorkLabels_Users_CreatorId",
                "WorkLabels");

            migrationBuilder.DropForeignKey(
                "FK_WorkLabels_Labels_LabelId",
                "WorkLabels");

            migrationBuilder.DropForeignKey(
                "FK_WorkLabels_Works_WorkId",
                "WorkLabels");

            migrationBuilder.DropForeignKey(
                "FK_Works_Users_CreatorId",
                "Works");

            migrationBuilder.DropForeignKey(
                "FK_Works_Events_EventId",
                "Works");

            migrationBuilder.DropForeignKey(
                "FK_Works_Users_ManagerId",
                "Works");

            migrationBuilder.DropForeignKey(
                "FK_Works_Works_ParentWorkId",
                "Works");

            migrationBuilder.DropForeignKey(
                "FK_Works_Projects_ProjectId",
                "Works");

            migrationBuilder.DropIndex(
                "IX_Works_CreatorId",
                "Works");

            migrationBuilder.DropIndex(
                "IX_Works_EventId",
                "Works");

            migrationBuilder.DropIndex(
                "IX_Works_ManagerId",
                "Works");

            migrationBuilder.DropIndex(
                "IX_Works_ParentWorkId",
                "Works");

            migrationBuilder.DropIndex(
                "IX_Works_ProjectId",
                "Works");

            migrationBuilder.DropIndex(
                "IX_WorkLabels_CreatorId",
                "WorkLabels");

            migrationBuilder.DropIndex(
                "IX_WorkLabels_LabelId",
                "WorkLabels");

            migrationBuilder.DropIndex(
                "IX_WorkLabels_WorkId",
                "WorkLabels");

            migrationBuilder.DropIndex(
                "IX_WorkHistorys_CreatorId",
                "WorkHistorys");

            migrationBuilder.DropIndex(
                "IX_WorkHistorys_ManagerId",
                "WorkHistorys");

            migrationBuilder.DropIndex(
                "IX_WorkHistorys_WorkId",
                "WorkHistorys");

            migrationBuilder.DropIndex(
                "IX_Users_CreatorId",
                "Users");

            migrationBuilder.DropIndex(
                "IX_Projects_CreatorId",
                "Projects");

            migrationBuilder.DropIndex(
                "IX_Projects_EventId",
                "Projects");

            migrationBuilder.DropIndex(
                "IX_Projects_ManagerId",
                "Projects");

            migrationBuilder.DropIndex(
                "IX_Labels_CreatorId",
                "Labels");

            migrationBuilder.DropIndex(
                "IX_Events_CreatorId",
                "Events");

            migrationBuilder.DropColumn(
                "ParentWorkId",
                "Works");
        }
    }
}