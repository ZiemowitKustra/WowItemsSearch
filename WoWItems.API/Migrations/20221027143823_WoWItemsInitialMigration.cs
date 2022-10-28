using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoWItems.API.Migrations
{
    public partial class WoWItemsInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: true),
                    Stamina = table.Column<int>(type: "int", nullable: false),
                    EquipEffect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseEffect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryStat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryStatType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondaryStatType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Armor", "Durability", "EquipEffect", "Name", "Stamina", "Type", "UseEffect" },
                values: new object[] { 1, 0, 145, "Deals 5 fire dmg to anyone who strikes you with mele attack", "Sulfuras, Hand of Ragnaros", 12, 1, null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Armor", "Durability", "EquipEffect", "Name", "Stamina", "Type", "UseEffect" },
                values: new object[] { 2, 679, 120, null, "Ruined Crest of Lorderon", 81, 0, null });

            migrationBuilder.InsertData(
                table: "PrimaryStat",
                columns: new[] { "Id", "ItemId", "PrimaryStatType", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 12 },
                    { 2, 2, 0, 133 }
                });

            migrationBuilder.InsertData(
                table: "SecondaryStat",
                columns: new[] { "Id", "ItemId", "SecondaryStatType", "Value" },
                values: new object[,]
                {
                    { 1, 2, 1, 21 },
                    { 2, 2, 2, 52 }
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
