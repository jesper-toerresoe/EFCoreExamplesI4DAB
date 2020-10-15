using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
  public class Author
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }

    public List<BookAuthors> BookAuthors { get; set; }
    public List<Book> Books { get; set; }
  }
}