using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DLL.Migrations
{
    public partial class Init_Migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Themes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CalendarDayID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    GlobalTaskID = table.Column<int>(nullable: true),
                    ThemeID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    Estimation = table.Column<TimeSpan>(nullable: true),
                    Requirement = table.Column<bool>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: true),
                    Frequency = table.Column<int>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Task_Task_GlobalTaskID",
                        column: x => x.GlobalTaskID,
                        principalTable: "Task",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Themes_ThemeID",
                        column: x => x.ThemeID,
                        principalTable: "Themes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    FreeTime = table.Column<TimeSpan>(nullable: false),
                    ConcreteTaskID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Days_Task_ConcreteTaskID",
                        column: x => x.ConcreteTaskID,
                        principalTable: "Task",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ConcreteTaskID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stages_Task_ConcreteTaskID",
                        column: x => x.ConcreteTaskID,
                        principalTable: "Task",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_ConcreteTaskID",
                table: "Days",
                column: "ConcreteTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_ConcreteTaskID",
                table: "Stages",
                column: "ConcreteTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CalendarDayID",
                table: "Task",
                column: "CalendarDayID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_GlobalTaskID",
                table: "Task",
                column: "GlobalTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ThemeID",
                table: "Task",
                column: "ThemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserID",
                table: "Task",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_UserID",
                table: "Themes",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Days_CalendarDayID",
                table: "Task",
                column: "CalendarDayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Task_ConcreteTaskID",
                table: "Days");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
