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
      new Set { SetId = 4, Code = "PCY", Name = "Mercadian Masques", CardCount = 144, Block = "Masques", BlockCode = "mmq" },
    };
    var cards = new[] { 
      new Card { CardId = 1, SetId = 1, Name = "Black Lotus", OracleText = "{T}, Sacrifice Black Lotus: Add three mana of any one color.", ManaCost = "{0}", ConvertedManaCost = 0.0m },
      new Card { CardId = 2, SetId = 1, Name = "Balance", OracleText = "Each player chooses a number of lands they control equal to the number of lands controlled by the player who controls the fewest, then sacrifices the rest. Players discard cards and sacrifice creatures the same way.", ManaCost = "{1}{W}", ConvertedManaCost = 2.0m },
      new Card { CardId = 3, SetId = 2, Name = "Gaea's Cradle", OracleText = "{T}: Add {G} for each creature you control.", ManaCost = "", ConvertedManaCost = 0.0m },
      new Card { CardId = 4, SetId = 2, Name = "Yawgmoth's Will", OracleText = "Until end of turn, you may play lands and cast spells from your graveyard. If a card would be put into your graveyard from anywhere this turn, exile that card instead. ", ManaCost = "{2}{B}", ConvertedManaCost = 3.0m },
    };
    modelBuilder.Entity<Set>().HasData(sets);
    modelBuilder.Entity<Card>().HasData(cards);
  }
}