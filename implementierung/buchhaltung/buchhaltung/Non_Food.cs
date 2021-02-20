using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{

    public class Non_Food : Einkauf
    {
        public Non_Food(decimal betrag) : base(betrag)
        {
            Steuersatz = 0.19m;
            Betrag_Brutto = betrag_Netto + SteuerBerechnen();
        }

        public override decimal SteuerBerechnen()
        {
            return betrag_Netto * Steuersatz;
        }
    }

}
