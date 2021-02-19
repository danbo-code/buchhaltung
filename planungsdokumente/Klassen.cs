using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Restaurant
    {
        private List<Personal> Personal_Liste { get; set; }
        private List<Einnahme> Einnahmen_Gesamt { get; set; }
        private List<Ausgaben> Ausgaben_Einkauf { get; set; }
        private List<Ausgaben> Ausgaben_Fix { get; set; }
        

        public Restaurant()
        {
            Personal_Liste = new List<Personal>();
            Einnahmen_Gesamt = new List<Einnahme>();
            Ausgaben_Einkauf = new List<Ausgaben>();
            Ausgaben_Fix = new List<Ausgaben>();
           
        }

        public void Personal_Hinzufuegen(string name, decimal stundenzahl, decimal stundenlohn)
        {
            Personal p = new Personal(name, stundenzahl, stundenlohn);

            Personal_Liste.Add(p);
        }

        public void Ausgabe_Fix_Hinzufuegen(string name, decimal betrag)
        {
            Fixkosten f = new Fixkosten(betrag, name);

            Ausgaben_Fix.Add(f);

        }

        public void Ausgabe_Einkauf_Food_Hinzufuegen(string name, decimal betrag)
        {
            Food f = new Food(betrag);

            Ausgaben_Einkauf.Add(f);

        }

        public void Ausgabe_Einkauf_Non_Food_Hinzufuegen(string name, decimal betrag)
        {
            Non_Food nf = new Non_Food(betrag);

            Ausgaben_Einkauf.Add(nf);

        }

        public decimal Summe_Einnahmen()
        {
            decimal summe = 0;

            foreach (Einnahme e in Einnahmen_Gesamt)
            {
                summe += e.Betrag_Netto;
            }

            return summe;
        }

        public decimal Summe_Ausgaben()
        {
            decimal summe = 0;

            foreach (Ausgaben a in Ausgaben_Fix)
            {
                summe += a.Betrag_Netto;
            }

            foreach (Ausgaben a in Ausgaben_Einkauf)
            {
                summe += a.Betrag_Netto;
            }

            foreach (Personal p in Personal_Liste)
            {
                summe += p.Verrechnen();
            }

            return summe;
        }

        public decimal GuV_Rechnung()
        {
            return Summe_Einnahmen() - Summe_Ausgaben();
        }


        public decimal Umsatzsteuern_Berechnen()
        {
            decimal umsatzsteuern = 0;

            foreach (Einnahme e in Einnahmen_Gesamt)
            {
                umsatzsteuern += e.SteuerBerechnen();
            }

            return umsatzsteuern;
        }


        public decimal Vorsteuern_Berechnen()
        {
            decimal Vorsteuer = 0;

            foreach (Einkauf e in Ausgaben_Einkauf)
            {
                Vorsteuer += e.SteuerBerechnen();
            }

            return Vorsteuer;
        }

        public decimal Gewerbesteuer_Berechnen()
        {
            if (GuV_Rechnung() > 0)
            {
                return GuV_Rechnung() * 0.035m;
            }

            return 0;
        }

        public decimal ReinGewinn()
        {
            return GuV_Rechnung() - Gewerbesteuer_Berechnen();
        }
    }


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

    public class Fixkosten : Ausgaben
    {
        private string Name;

        public Fixkosten(decimal betrag, string name) : base(betrag)
        {
            Name = name;
        }
    }


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
