using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{

    public class Fixkosten : Ausgaben
    {
        private string Name;

        public Fixkosten(decimal betrag, string name) : base(betrag)
        {
            Name = name;
        }
    }

}
