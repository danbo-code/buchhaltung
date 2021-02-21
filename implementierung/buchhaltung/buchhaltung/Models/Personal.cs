using System;
using System.Collections.Generic;

#nullable disable

namespace Shell.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Arbeitszeitens = new HashSet<Arbeitszeiten>();
        }

        public int IdPersonal { get; set; }
        public string Nachname { get; set; }
        public decimal? Stundenlohn { get; set; }

        public virtual ICollection<Arbeitszeiten> Arbeitszeitens { get; set; }
    }
}
