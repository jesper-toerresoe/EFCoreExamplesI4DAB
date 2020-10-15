using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAdv.Models
{
    public partial class Bil
    {
        public Bil()
        {
            StaarI = new HashSet<StaarI>();
        }

        public long BilId { get; set; }
        public string Nummerplade { get; set; }
        public string EjerNavn { get; set; }
        public string Telf { get; set; }

        public virtual ICollection<StaarI> StaarI { get; set; }
    }
}
