using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAdv.Models
{
    public partial class GarageAnlaeg
    {
        public GarageAnlaeg()
        {
            StaarI = new HashSet<StaarI>();
        }

        public long GarageId { get; set; }
        public string Navn { get; set; }
        public string By { get; set; }

        public virtual ICollection<StaarI> StaarI { get; set; }
    }
}
