using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{

    public abstract class Einnahme
    {
        protected decimal betrag_Netto;
        public decimal Betrag_Netto { get { return betrag_Netto; } }
        protected decimal betrag_Brutto;
        public decimal Betrag_Brutto { get { return betrag_Brutto; } }
        private DateTime Datum;
        protected decimal Steuersatz { get; set; }

        public Einnahme(decimal betrag)
        {
            betrag_Netto = betrag;
            Datum = DateTime.Now;
        }

        public abstract decimal SteuerBerechnen();



    }

}    