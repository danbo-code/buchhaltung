using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{
    
    public class ToGo : Einnahme
    {
        public ToGo(decimal betrag) : base(betrag)
        {
            Steuersatz = 0.07m;

            betrag_Brutto = betrag_Netto + SteuerBerechnen();
        }

        public override decimal SteuerBerechnen()
        {
            return betrag_Netto * Steuersatz;
        }
    }
}
