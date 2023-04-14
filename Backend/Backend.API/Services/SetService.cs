using Microsoft.EntityFrameworkCore;
using Backend.API.Data;

namespace Backend.API.Services;

public interface ISetService {
  public Task<List<SetDTO>> GetSets();
  public Task<SingleSetDTO?> GetSet(int id);

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
        Id = s.SetId, 
      }).ToListAsync();
  }
  public Task<SingleSetDTO?> GetSet(int id)
  {
    return _dbContext.Sets
      .Where(s => s.SetId == id)
      .Include(c => c.Cards)
      .Select(s => new SingleSetDTO {
        Name = s.Name,
        Id = s.SetId,
        Cards = s.Cards.Select(c => new CardForSetDTO { 
          Name = c.Name, 
          Id = c.CardId 
        }).ToList()
      }).FirstOrDefaultAsync();
  }
}


public record SetDTO {
  public required String Name { get; set; }
  public int Id { get; set; }
}

public record SingleSetDTO: SetDTO {
  public required ICollection<CardForSetDTO> Cards { get; set; }
}

public record CardForSetDTO {
  public required String Name { get; set; }
  public required int Id { get; set; }
}