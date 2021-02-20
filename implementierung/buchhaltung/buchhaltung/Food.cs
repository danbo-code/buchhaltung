using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{

    public class Food : Einkauf
    {
        public Food(decimal betrag) : base(betrag)
        {
            Steuersatz = 0.07m;
            Betrag_Brutto = Betrag_Netto + SteuerBerechnen();
        }

        public override decimal SteuerBerechnen()
        {
            return Betrag_Netto * Steuersatz;
        }
    }
  
}
