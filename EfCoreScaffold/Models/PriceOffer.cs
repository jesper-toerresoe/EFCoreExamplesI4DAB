using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class PriceOffer
    {
        public int Id { get; set; }
        public float NewPrice { get; set; }
        public string PromotionText { get; set; }
        public int BookIsbn { get; set; }

        public virtual Book BookIsbnNavigation { get; set; }
    }
}
