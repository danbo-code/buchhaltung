using System;
using System.Collections.Generic;

#nullable disable

namespace Shell.Models
{
    public partial class Arbeitszeiten
    {
        public int IdArbeitszeit { get; set; }
        public decimal? Arbeitsstunden { get; set; }
        public DateTime? Datum { get; set; }
        public int? IdPersonal { get; set; }

        public virtual Personal IdPersonalNavigation { get; set; }
    }
}
