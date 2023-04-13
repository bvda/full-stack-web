namespace Backend.Model;

public class Card {
  public int CardId { get; set; }
  public string ManaCost { get; set; }
  public decimal ConvertedManaCost { get; set; }
  public string Name { get; set; }
  public string OracleText { get; set; }
  public int SetId {get; set; }
  public Set Set { get; set; }
}