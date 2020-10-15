namespace EfCoreScaffold.Models
{
  public class Review
  {
    public int Id { get; set; }
    public string Votername { get; set; }
    public string Comment { get; set; }
    public int NumStars { get; set; }

    public int BookIsbn { get; set; }
    public Book Book { get; set; }
    public string VoterFirstName { get; set; }
    public string VoterLastName { get; set; }
    public Voter Voter { get; set; }

  }
}