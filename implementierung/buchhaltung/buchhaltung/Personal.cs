using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buchhaltung
{
    
    public class Personal
    {
        private string Name;

        private decimal Stundenanzahl;

        private decimal Stundenlohn;

        public Personal(string name, decimal stundenzahl, decimal stundenlohn)
        {
            Name = name;
            Stundenanzahl = stundenzahl;
            Stundenlohn = stundenlohn;
        }

        public decimal Verrechnen()
        {
            return Stundenanzahl * Stundenlohn;
        }
    }

}
