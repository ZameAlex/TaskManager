using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DLL.Migrations
{
    public partial class NicknameWasAddedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Task_ConcreteTaskID",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Task_ConcreteTaskID",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Days_CalendarDayID",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Task_GlobalTaskID",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Themes_ThemeID",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Users_UserID",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Users_UserID",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "CalendarDays");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Themes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Themes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Themes_UserID",
                table: "Themes",
                newName: "IX_Themes_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Task",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ThemeID",
                table: "Task",
                newName: "ThemeId");

            migrationBuilder.RenameColumn(
                name: "GlobalTaskID",
                table: "Task",
                newName: "GlobalTaskId");

            migrationBuilder.RenameColumn(
                name: "CalendarDayID",
                table: "Task",
                newName: "CalendarDayId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Task",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UserID",
                table: "Task",
                newName: "IX_Task_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ThemeID",
                table: "Task",
                newName: "IX_Task_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_GlobalTaskID",
                table: "Task",
                newName: "IX_Task_GlobalTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CalendarDayID",
                table: "Task",
                newName: "IX_Task_CalendarDayId");

            migrationBuilder.RenameColumn(
                name: "ConcreteTaskID",
                table: "Stages",
                newName: "ConcreteTaskId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Stages",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Stages_ConcreteTaskID",
                table: "Stages",
                newName: "IX_Stages_ConcreteTaskId");

            migrationBuilder.RenameColumn(
                name: "ConcreteTaskID",
                table: "CalendarDays",
                newName: "ConcreteTaskId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CalendarDays",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Days_ConcreteTaskID",
                table: "CalendarDays",
                newName: "IX_CalendarDays_ConcreteTaskId");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalendarDays",
                table: "CalendarDays",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarDays_Task_ConcreteTaskId",
                table: "CalendarDays",
                column: "ConcreteTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Task_ConcreteTaskId",
                table: "Stages",
                column: "ConcreteTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_CalendarDays_CalendarDayId",
                table: "Task",
                column: "CalendarDayId",
                principalTable: "CalendarDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Task_GlobalTaskId",
                table: "Task",
                column: "GlobalTaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Themes_ThemeId",
                table: "Task",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Users_UserId",
                table: "Task",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Users_UserId",
                table: "Themes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarDays_Task_ConcreteTaskId",
                table: "CalendarDays");

            migrationBuilder.DropForeignKey(
                name: "FK_Stages_Task_ConcreteTaskId",
                table: "Stages");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_CalendarDays_CalendarDayId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Task_GlobalTaskId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Themes_ThemeId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Users_UserId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Users_UserId",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalendarDays",
                table: "CalendarDays");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "CalendarDays",
                newName: "Days");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Themes",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Themes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Themes_UserId",
                table: "Themes",
                newName: "IX_Themes_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Task",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ThemeId",
                table: "Task",
                newName: "ThemeID");

            migrationBuilder.RenameColumn(
                name: "GlobalTaskId",
                table: "Task",
                newName: "GlobalTaskID");

            migrationBuilder.RenameColumn(
                name: "CalendarDayId",
                table: "Task",
                newName: "CalendarDayID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UserId",
                table: "Task",
                newName: "IX_Task_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Task_ThemeId",
                table: "Task",
                newName: "IX_Task_ThemeID");

            migrationBuilder.RenameIndex(
                name: "IX_Task_GlobalTaskId",
                table: "Task",
                newName: "IX_Task_GlobalTaskID");

            migrationBuilder.RenameIndex(
                name: "IX_Task_CalendarDayId",
                table: "Task",
                newName: "IX_Task_CalendarDayID");

            migrationBuilder.RenameColumn(
                name: "ConcreteTaskId",
                table: "Stages",
                newName: "ConcreteTaskID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stages",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Stages_ConcreteTaskId",
                table: "Stages",
                newName: "IX_Stages_ConcreteTaskID");

            migrationBuilder.RenameColumn(
                name: "ConcreteTaskId",
                table: "Days",
                newName: "ConcreteTaskID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Days",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CalendarDays_ConcreteTaskId",
                table: "Days",
                newName: "IX_Days_ConcreteTaskID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Task_ConcreteTaskID",
                table: "Days",
                column: "ConcreteTaskID",
                principalTable: "Task",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stages_Task_ConcreteTaskID",
                table: "Stages",
                column: "ConcreteTaskID",
                principalTable: "Task",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Days_CalendarDayID",
                table: "Task",
                column: "CalendarDayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Task_GlobalTaskID",
                table: "Task",
                column: "GlobalTaskID",
                principalTable: "Task",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Themes_ThemeID",
                table: "Task",
                column: "ThemeID",
                principalTable: "Themes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Users_UserID",
                table: "Task",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Users_UserID",
                table: "Themes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
