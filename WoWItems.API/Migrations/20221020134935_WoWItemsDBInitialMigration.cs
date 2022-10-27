using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoWItems.API.Migrations
{
    public partial class WoWItemsDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Armor = table.Column<int>(type: "INTEGER", nullable: true),
                    Stamina = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipEffect = table.Column<string>(type: "TEXT", nullable: true),
                    UseEffect = table.Column<string>(type: "TEXT", nullable: true),
                    Durabity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrimaryStatType = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryStat_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SecondaryStatType = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryStat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondaryStat_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryStat_ItemId",
                table: "PrimaryStat",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryStat_ItemId",
                table: "SecondaryStat",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimaryStat");

            migrationBuilder.DropTable(
                name: "SecondaryStat");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
