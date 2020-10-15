using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
  public class Book
  {
    public int Isbn10 { get; set; }
    public int Isbn13 { get; set; }
    public float price { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Pages { get; set; }
    public DateTime PublishedOn { get; set; }

    public PriceOffer PriceOffer { get; set; }
    public List<BookAuthors> BookAuthors { get; set; }
    public List<Review> Reviews { get; set; }

    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public Author PrimaryAuthor { get; set; }

    public List<Edition> Editions { get; set; }
    public int NextBookIsbn10 { get; set; }
    public Book NextBook { get; set; }
    public Book PreviousBook { get; set; }
  }
}