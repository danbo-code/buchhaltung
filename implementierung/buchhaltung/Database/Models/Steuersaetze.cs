using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Steuersaetze
    {
        public Steuersaetze()
        {
            Einkaufs = new HashSet<Einkauf>();
            Verkaufs = new HashSet<Verkauf>();
        }

        public int IdSteuersatz { get; set; }
        public string Bezeichnung { get; set; }
        public decimal? Steuersatz { get; set; }

        public virtual ICollection<Einkauf> Einkaufs { get; set; }
        public virtual ICollection<Verkauf> Verkaufs { get; set; }
    }
}
