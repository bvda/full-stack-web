using Microsoft.EntityFrameworkCore;
using Backend.API.Data;

namespace Backend.API.Services;

public interface ISetService {
  public Task<List<SetDTO>> GetSets();
}

public class SetService : ISetService {
  private readonly CardContext _dbContext;
  public SetService(CardContext dbContext) {
    _dbContext = dbContext;
  }

  public Task<List<SetDTO>> GetSets() {
    return _dbContext.Sets
      .Include(c => c.Cards)
      .Select(s => new SetDTO { 
        Name = s.Name, 
        Cards = s.Cards.Select(c => new CardForSetDTO { 
          Name = c.Name, 
          CardId = c.CardId 
        }).ToList(), 
      }).ToListAsync();
  }
}

public record SetDTO {
  public required String Name { get; set; }
  public required ICollection<CardForSetDTO> Cards { get; set; }
}

public record CardForSetDTO {
  public required String Name { get; set; }
  public required int CardId { get; set; }
}