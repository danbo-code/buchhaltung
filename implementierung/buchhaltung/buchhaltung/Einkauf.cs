using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{
    

    public abstract class Einkauf : Ausgaben
    {
        protected decimal betrag_Brutto;
        public decimal Betrag_Brutto { get { return betrag_Brutto; } set { betrag_Brutto = Betrag_Brutto; } }
        protected decimal Steuersatz;
        public Einkauf(decimal betrag) : base(betrag)
        {

        }

        public abstract decimal SteuerBerechnen();
    }


}
