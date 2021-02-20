using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{
    
    public class InHouse : Einnahme
    {
        public InHouse(decimal betrag) : base(betrag)
        {
            Steuersatz = 0.19m;

            betrag_Brutto = betrag_Netto + SteuerBerechnen();
        }

        public override decimal SteuerBerechnen()
        {
            return betrag_Netto * Steuersatz;
        }
    }

}
