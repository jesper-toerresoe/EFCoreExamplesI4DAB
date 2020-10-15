using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAdv.Models
{
    public partial class Vaerksted
    {
        public Vaerksted()
        {
            StaarI = new HashSet<StaarI>();
        }

        public long VaerkstedsId { get; set; }
        public string Vnavn { get; set; }
        public string By { get; set; }

        public virtual ICollection<StaarI> StaarI { get; set; }
    }
}
