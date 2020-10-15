using System;
using System.Collections.Generic;

namespace EfCoreScaffold.Models
{
    public partial class Edition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookIsbn10 { get; set; }

        public virtual Book BookIsbn10Navigation { get; set; }
    }
}
