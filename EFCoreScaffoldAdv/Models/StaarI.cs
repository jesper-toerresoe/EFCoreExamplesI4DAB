using System;
using System.Collections.Generic;

namespace EFCoreScaffoldAdv.Models
{
    public partial class StaarI
    {
        public long GarageId { get; set; }
        public long BilId { get; set; }
        public long VaerkstedsId { get; set; }

        public virtual Bil Bil { get; set; }
        public virtual GarageAnlaeg Garage { get; set; }
        public virtual Vaerksted Vaerksteds { get; set; }
    }
}
