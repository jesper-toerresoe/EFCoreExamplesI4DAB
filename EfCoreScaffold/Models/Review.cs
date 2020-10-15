using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Votername { get; set; }
        public string Comment { get; set; }
        public int NumStars { get; set; }
        public int BookIsbn { get; set; }
        public string VoterFirstName { get; set; }
        public string VoterLastName { get; set; }

        public virtual Book BookIsbnNavigation { get; set; }
        public virtual Voter Voter { get; set; }
    }
}
