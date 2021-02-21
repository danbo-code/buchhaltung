using System;
using System.Collections.Generic;

#nullable disable

namespace Database.Models
{
    public partial class Fixkosten
    {
        public int IdFixkosten { get; set; }
        public string Bezeichnung { get; set; }
        public decimal? Betrag { get; set; }
        public DateTime? Datum { get; set; }
    }
}
