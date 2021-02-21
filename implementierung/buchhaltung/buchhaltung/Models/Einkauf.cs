using System;
using System.Collections.Generic;

#nullable disable

namespace Shell.Models
{
    public partial class Einkauf
    {
        public int IdEinkauf { get; set; }
        public decimal? BetragNetto { get; set; }
        public DateTime? Datum { get; set; }
        public int? IdSteuersatz { get; set; }

        public virtual Steuersaetze IdSteuersatzNavigation { get; set; }
    }
}
