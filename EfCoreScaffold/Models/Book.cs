using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthors>();
            Edition = new HashSet<Edition>();
            Review = new HashSet<Review>();
        }

        public float Price { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public int Isbn13 { get; set; }
        public int Isbn10 { get; set; }
        public int Pages { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int NextBookIsbn10 { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book NextBookIsbn10Navigation { get; set; }
        public virtual Book InverseNextBookIsbn10Navigation { get; set; }
        public virtual PriceOffer PriceOffer { get; set; }
        public virtual ICollection<BookAuthors> BookAuthors { get; set; }
        public virtual ICollection<Edition> Edition { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
