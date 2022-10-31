using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoWItems.API.Migrations
{
    public partial class WoWItemsInitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrimaryStat_ItemId",
                table: "PrimaryStat");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryStat_ItemId",
                table: "PrimaryStat",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PrimaryStat_ItemId",
                table: "PrimaryStat");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryStat_ItemId",
                table: "PrimaryStat",
                column: "ItemId",
                unique: true);
        }
    }
}
