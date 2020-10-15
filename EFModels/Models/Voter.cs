using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public class Voter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string VoterOrg { get; set; }

        public List<Review> Reviewers { get; set; }
    }
}