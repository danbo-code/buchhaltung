using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{


    public abstract class Ausgaben
    {
        protected decimal betrag_Netto;
        public decimal Betrag_Netto { get { return betrag_Netto; } }

        private DateTime Datum;


        public Ausgaben(decimal betrag)
        {
            betrag_Netto = betrag;
        }

    }

} 