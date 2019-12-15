using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Track_Sport_Events_MVC.Migrations
{
    public partial class TrackSportDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Runner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GoldMedals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackSportEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackSportEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimingRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunnerId = table.Column<int>(nullable: false),
                    TrackSportEventId = table.Column<int>(nullable: false),
                    RecordedTime = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimingRecord_Runner_RunnerId",
                        column: x => x.RunnerId,
                        principalTable: "Runner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimingRecord_TrackSportEvent_TrackSportEventId",
                        column: x => x.TrackSportEventId,
                        principalTable: "TrackSportEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimingRecord_RunnerId",
                table: "TimingRecord",
                column: "RunnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TimingRecord_TrackSportEventId",
                table: "TimingRecord",
                column: "TrackSportEventId");

            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimingRecord");

            migrationBuilder.DropTable(
                name: "Runner");

            migrationBuilder.DropTable(
                name: "TrackSportEvent");
        }
    }
}
