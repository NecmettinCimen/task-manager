using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.Migrations
{
    public partial class foreginkeysandparentworkid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentWorkId",
                table: "Works",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_CreatorId",
                table: "Works",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_EventId",
                table: "Works",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ManagerId",
                table: "Works",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ParentWorkId",
                table: "Works",
                column: "ParentWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ProjectId",
                table: "Works",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLabels_CreatorId",
                table: "WorkLabels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLabels_LabelId",
                table: "WorkLabels",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLabels_WorkId",
                table: "WorkLabels",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistorys_CreatorId",
                table: "WorkHistorys",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistorys_ManagerId",
                table: "WorkHistorys",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistorys_WorkId",
                table: "WorkHistorys",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                table: "Users",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EventId",
                table: "Projects",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerId",
                table: "Projects",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_CreatorId",
                table: "Labels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_CreatorId",
                table: "Events",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Users_CreatorId",
                table: "Labels",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_CreatorId",
                table: "Projects",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Events_EventId",
                table: "Projects",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_ManagerId",
                table: "Projects",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreatorId",
                table: "Users",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistorys_Users_CreatorId",
                table: "WorkHistorys",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistorys_Users_ManagerId",
                table: "WorkHistorys",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistorys_Works_WorkId",
                table: "WorkHistorys",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLabels_Users_CreatorId",
                table: "WorkLabels",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLabels_Labels_LabelId",
                table: "WorkLabels",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLabels_Works_WorkId",
                table: "WorkLabels",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_CreatorId",
                table: "Works",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Events_EventId",
                table: "Works",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Users_ManagerId",
                table: "Works",
                column: "ManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Works_ParentWorkId",
                table: "Works",
                column: "ParentWorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Projects_ProjectId",
                table: "Works",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_CreatorId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Users_CreatorId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_CreatorId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Events_EventId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_ManagerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreatorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistorys_Users_CreatorId",
                table: "WorkHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistorys_Users_ManagerId",
                table: "WorkHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistorys_Works_WorkId",
                table: "WorkHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLabels_Users_CreatorId",
                table: "WorkLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLabels_Labels_LabelId",
                table: "WorkLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLabels_Works_WorkId",
                table: "WorkLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_CreatorId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Events_EventId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Users_ManagerId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Works_ParentWorkId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Projects_ProjectId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_CreatorId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_EventId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ManagerId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ParentWorkId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_ProjectId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_WorkLabels_CreatorId",
                table: "WorkLabels");

            migrationBuilder.DropIndex(
                name: "IX_WorkLabels_LabelId",
                table: "WorkLabels");

            migrationBuilder.DropIndex(
                name: "IX_WorkLabels_WorkId",
                table: "WorkLabels");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistorys_CreatorId",
                table: "WorkHistorys");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistorys_ManagerId",
                table: "WorkHistorys");

            migrationBuilder.DropIndex(
                name: "IX_WorkHistorys_WorkId",
                table: "WorkHistorys");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreatorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CreatorId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EventId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Labels_CreatorId",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatorId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ParentWorkId",
                table: "Works");
        }
    }
}
