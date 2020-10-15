namespace EfCoreScaffold.Models
{
  public class Edition
  {
    public int ID { get; set; }
    public string Name { get; set; }

    public int BookIsbn10 { get; set; }
    public Book Book { get; set; }
  }
}