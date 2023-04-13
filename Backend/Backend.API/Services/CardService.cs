using Microsoft.EntityFrameworkCore;
using Backend.API.Data;

namespace Backend.API.Services;

public interface ICardService {
  public Task<List<CardDTO>> GetCards();
  public Task<SingleCardDTO> GetCard(int id);
}

public class CardService : ICardService {
  private readonly CardContext _dbContext;
  public CardService(CardContext dbContext) {
    _dbContext = dbContext;
  }

  public Task<List<CardDTO>> GetCards() {
    return _dbContext.Cards
      .Include(c => c.Set)
      .Select(c => new CardDTO { 
        Name = c.Name, 
        Set = c.Set.Name, 
      }
    ).ToListAsync();
  }

  public Task<SingleCardDTO?> GetCard(int id) {
    return _dbContext.Cards
      .Include(c => c.Set)
      .Where(c => c.CardId == id)
      .Select(c => new SingleCardDTO { 
        Name = c.Name,
        ManaCost = c.ManaCost,
        ConvertedManaCost = c.ConvertedManaCost,
        OracleText = c.OracleText,
        Set = c.Set.Name, 
      }
    ).FirstOrDefaultAsync();
  }
}

public record CardDTO {
  public required String Name { get; set; }
  public required String Set { get; set; }
}

public record SingleCardDTO : CardDTO {
  public required String ManaCost { get; set; }
  public decimal ConvertedManaCost { get; set; }
  public required String OracleText { get; set; }
}