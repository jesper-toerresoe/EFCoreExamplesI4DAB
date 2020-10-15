using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
            BookAuthors = new HashSet<BookAuthors>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<BookAuthors> BookAuthors { get; set; }
    }
}
