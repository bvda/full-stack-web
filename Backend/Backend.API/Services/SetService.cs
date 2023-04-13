using Microsoft.EntityFrameworkCore;
using Backend.API.Data;

namespace Backend.API.Services;

public class SetService {
  private readonly CardContext _dbContext;
  public SetService(CardContext dbContext) {
    _dbContext = dbContext;
  }

  public Task<List<SetDTO>> GetSets() {
    return _dbContext.Sets
      .Include(s => s.Cards)
      .Select(c => new SetDTO { 
        Name = c.Name, 
        Cards = c.Cards.Select(c => c.Name).ToList(), 
      }
    ).ToListAsync();
  }
}

public record SetDTO {
  public required String Name { get; set; }
  public required ICollection<String> Cards { get; set; }
}