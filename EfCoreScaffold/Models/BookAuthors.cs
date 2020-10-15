using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class BookAuthors
    {
        public int BookAuthorsId { get; set; }
        public int BookIsbn { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book BookIsbnNavigation { get; set; }
    }
}
