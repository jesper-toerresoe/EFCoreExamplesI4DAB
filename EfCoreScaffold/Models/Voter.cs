using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class Voter
    {
        public Voter()
        {
            Review = new HashSet<Review>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VoterOrg { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
