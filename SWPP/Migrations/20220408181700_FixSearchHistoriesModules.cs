using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWPP.WebApi.Migrations
{
    public partial class FixSearchHistoriesModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_SearchHistories_SearchHistoryId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_SearchHistoryId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "SearchHistoryId",
                table: "Modules");

            migrationBuilder.CreateTable(
                name: "ModuleSearchHistory",
                columns: table => new
                {
                    ModulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchHistoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSearchHistory", x => new { x.ModulesId, x.SearchHistoriesId });
                    table.ForeignKey(
                        name: "FK_ModuleSearchHistory_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleSearchHistory_SearchHistories_SearchHistoriesId",
                        column: x => x.SearchHistoriesId,
                        principalTable: "SearchHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleSearchHistory_SearchHistoriesId",
                table: "ModuleSearchHistory",
                column: "SearchHistoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleSearchHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "SearchHistoryId",
                table: "Modules",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_SearchHistoryId",
                table: "Modules",
                column: "SearchHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_SearchHistories_SearchHistoryId",
                table: "Modules",
                column: "SearchHistoryId",
                principalTable: "SearchHistories",
                principalColumn: "Id");
        }
    }
}
