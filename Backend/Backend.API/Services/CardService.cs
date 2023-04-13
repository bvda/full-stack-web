using Microsoft.EntityFrameworkCore;
using Backend.API.Data;

namespace Backend.API.Services;

public class CardService {
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
}

public record CardDTO {
  public required String Name { get; set; }
  public required String Set { get; set; }
}