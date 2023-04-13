using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    SetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CardCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Block = table.Column<string>(type: "TEXT", nullable: true),
                    BlockCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.SetId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManaCost = table.Column<string>(type: "TEXT", nullable: false),
                    ConvertedManaCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    OracleText = table.Column<string>(type: "TEXT", nullable: false),
                    SetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_Cards_Sets_SetId",
                        column: x => x.SetId,
                        principalTable: "Sets",
                        principalColumn: "SetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "SetId", "Block", "BlockCode", "CardCount", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "", "", 295, "LEA", "Limited Edition Alpha" },
                    { 2, "Urza", "usg", 365, "USG", "Urza's Saga" },
                    { 3, "Masques", "mmq", 350, "MMQ", "Mercadian Masques" },
                    { 4, "Masques", "mmq", 144, "PCY", "Prophecy" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "ConvertedManaCost", "ManaCost", "Name", "OracleText", "SetId" },
                values: new object[,]
                {
                    { 1, 0.0m, "{0}", "Black Lotus", "{T}, Sacrifice Black Lotus: Add three mana of any one color.", 1 },
                    { 2, 2.0m, "{1}{W}", "Balance", "Each player chooses a number of lands they control equal to the number of lands controlled by the player who controls the fewest, then sacrifices the rest. Players discard cards and sacrifice creatures the same way.", 1 },
                    { 3, 0.0m, "", "Gaea's Cradle", "{T}: Add {G} for each creature you control.", 2 },
                    { 4, 3.0m, "{2}{B}", "Yawgmoth's Will", "Until end of turn, you may play lands and cast spells from your graveyard.\nIf a card would be put into your graveyard from anywhere this turn, exile that card instead. ", 2 },
                    { 5, 0.0m, "", "Rishadan Port", "{T}: Add {C}.\n{1}, {T}: Tap target land.", 3 },
                    { 6, 3.0m, "{2}{G}", "Food Chain", "Exile a creature you control: Add X mana of any one color, where X is 1 plus the exiled creature's mana value. Spend this mana only to cast creature spells.", 3 },
                    { 7, 3.0m, "{2}{U}", "Rhystic Study", "Whenever an opponent casts a spell, you may draw a card unless that player pays {1}.", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_SetId",
                table: "Cards",
                column: "SetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Sets");
        }
    }
}
