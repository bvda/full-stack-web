namespace Backend.Model;

public class Set {
  public int SetId { get; set; }
  public string Code { get; set; }
  public string Name { get; set; }
  public int CardCount { get; set; }
  public string? Block { get; set; }
  public string? BlockCode { get; set; }

  public ICollection<Card> Cards { get; set; }
}