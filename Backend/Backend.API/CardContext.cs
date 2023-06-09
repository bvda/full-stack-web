using Microsoft.EntityFrameworkCore;
using Backend.Model;

namespace Backend.API.Data;

public class CardContext : DbContext
{

  public DbSet<Card> Cards  { get; set; }
  public DbSet<Set> Sets  { get; set; }
  public string DbPath { get; } = "Database.db";
    
  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlite($"DataSource={DbPath}");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var sets = new [] {
      new Set { SetId = 1, Code = "LEA", Name = "Limited Edition Alpha", CardCount = 295, Block ="", BlockCode = "" },
      new Set { SetId = 2, Code = "USG", Name = "Urza's Saga", CardCount = 365, Block = "Urza", BlockCode = "usg" }, 
      new Set { SetId = 3, Code = "MMQ", Name = "Mercadian Masques", CardCount = 350, Block = "Masques", BlockCode = "mmq" },
      new Set { SetId = 4, Code = "PCY", Name = "Prophecy", CardCount = 144, Block = "Masques", BlockCode = "mmq" },
    };
    var cards = new[] { 
      new Card { CardId = 1, SetId = 1, Name = "Black Lotus", OracleText = "{T}, Sacrifice Black Lotus: Add three mana of any one color.", ManaCost = "{0}", ConvertedManaCost = 0.0m },
      new Card { CardId = 2, SetId = 1, Name = "Balance", OracleText = "Each player chooses a number of lands they control equal to the number of lands controlled by the player who controls the fewest, then sacrifices the rest. Players discard cards and sacrifice creatures the same way.", ManaCost = "{1}{W}", ConvertedManaCost = 2.0m },
      new Card { CardId = 3, SetId = 2, Name = "Gaea's Cradle", OracleText = "{T}: Add {G} for each creature you control.", ManaCost = "", ConvertedManaCost = 0.0m },
      new Card { CardId = 4, SetId = 2, Name = "Yawgmoth's Will", OracleText = "Until end of turn, you may play lands and cast spells from your graveyard.\nIf a card would be put into your graveyard from anywhere this turn, exile that card instead. ", ManaCost = "{2}{B}", ConvertedManaCost = 3.0m },
      new Card { CardId = 5, SetId = 3, Name = "Rishadan Port", OracleText = "{T}: Add {C}.\n{1}, {T}: Tap target land.", ManaCost = "", ConvertedManaCost = 0.0m },
      new Card { CardId = 6, SetId = 3, Name = "Food Chain", OracleText = "Exile a creature you control: Add X mana of any one color, where X is 1 plus the exiled creature's mana value. Spend this mana only to cast creature spells.", ManaCost = "{2}{G}", ConvertedManaCost = 3.0m },
      new Card { CardId = 7, SetId = 4, Name = "Rhystic Study", OracleText = "Whenever an opponent casts a spell, you may draw a card unless that player pays {1}.", ManaCost = "{2}{U}", ConvertedManaCost = 3.0m },
    };
    modelBuilder.Entity<Set>().HasData(sets);
    modelBuilder.Entity<Card>().HasData(cards);
  }
}