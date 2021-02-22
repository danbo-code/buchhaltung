using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Database;
using Database.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Shell.Views
{
    /// <summary>
    /// Interaction logic for Calculation.xaml
    /// </summary>
    /// 

    public class Calc
    {
        private buchhaltungContext Context = new buchhaltungContext();
        private ICollectionView CollectionView;


        int Jahr;
        int Monat;

        public decimal Ausgaben_Food { get; set; }
        public decimal Ausgaben_Non_Food { get; set; }
        public decimal Personalkosten { get; set; }
        public decimal Vorsteuer { get; set; }
        public decimal Umsatz { get; set; }
        public decimal Umsatzsteuer { get; set; }
        public decimal Gewinn { get; set; }
        public decimal Gewerbesteuer { get; set; }
        public decimal Reingewinn { get; set; }
        public decimal Fixkosten { get; set; }

        public Calc(int jahr)
        {
            Jahr = jahr;
            Monat = 0;

            Ausgaben_Food = Math.Round(Ausgaben_Food_berechnen(), 2);
            Ausgaben_Non_Food = Math.Round(Ausgaben_Non_Food_berechnen(), 2);
            Personalkosten = Math.Round(Ausgaben_Personal_berechnen(), 2);
            Umsatz = Math.Round((Umsatz_InHouse_berechnen() + Umsatz_ToGo_berechnen()), 2);
            Umsatzsteuer = Math.Round(((Umsatz_InHouse_berechnen() * 0.07m) + (Umsatz_ToGo_berechnen() * 0.19m)), 2);
            Vorsteuer = Math.Round(((Ausgaben_Food_berechnen() * 0.07m) + (Ausgaben_Non_Food_berechnen() * 0.19m)), 2);
            Fixkosten = Math.Round(Ausgaben_Fixkosten_berechnen(), 2);
            Gewinn = Math.Round((Umsatz - Ausgaben_Food - Ausgaben_Non_Food - Personalkosten - Fixkosten), 2);
            Gewerbesteuer = Math.Round((Gewinn * 0.035m), 2);
            Reingewinn = Math.Round((Gewinn - Gewerbesteuer), 2);
        }

        public Calc(int jahr, int monat)
        {
            Jahr = jahr;
            Monat = monat;

            Ausgaben_Food = Math.Round(Ausgaben_Food_berechnen(), 2);
            Ausgaben_Non_Food = Math.Round(Ausgaben_Non_Food_berechnen(), 2);
            Personalkosten = Math.Round(Ausgaben_Personal_berechnen(), 2);
            Umsatz = Math.Round((Umsatz_InHouse_berechnen() + Umsatz_ToGo_berechnen()), 2);
            Umsatzsteuer = Math.Round(((Umsatz_InHouse_berechnen() * 0.07m) + (Umsatz_ToGo_berechnen() * 0.19m)), 2);
            Vorsteuer = Math.Round(((Ausgaben_Food_berechnen() * 0.07m) + (Ausgaben_Non_Food_berechnen() * 0.19m)), 2);
            Fixkosten = Math.Round(Ausgaben_Fixkosten_berechnen(),2);
            Gewinn = Math.Round((Umsatz - Ausgaben_Food - Ausgaben_Non_Food - Personalkosten - Fixkosten), 2);
            Gewerbesteuer = Math.Round((Gewinn * 0.035m), 2);
            Reingewinn = Math.Round((Gewinn - Gewerbesteuer), 2);
        }


        private decimal Ausgaben_Food_berechnen()
        {
            

            decimal Summe = 0;

            Context.Einkauf.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());

            var cv = CollectionView.Cast<Einkauf>().ToList();
            if (Monat == 0)
            {
              cv =  cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).ToList();
            }

            else
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[1]) == Monat).ToList();
            }

            cv.Where(x => x.IdSteuersatz == 1).ToList().ForEach(x => Summe += (decimal)x.BetragNetto);

            return Summe;
        }

        

        private decimal Ausgaben_Non_Food_berechnen()
        {
            decimal Summe = 0;

            Context.Einkauf.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());

            var cv = CollectionView.Cast<Einkauf>().ToList();
            if (Monat == 0)
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).ToList();
            }

            else
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[1]) == Monat).ToList();
            }

            cv.Where(x => x.IdSteuersatz == 2).ToList().ForEach(x => Summe += (decimal)x.BetragNetto);

            return Summe;
        }

        private decimal Ausgaben_Personal_berechnen()
        {
            ICollectionView collectionView2;

            decimal PersonKosten;
            decimal GesamtKosten = 0;

            Context.Personal.Load();
            Context.Arbeitszeiten.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Personal.Local.ToObservableCollection());

            
            foreach(Personal p in CollectionView)
            {

                PersonKosten = 0;
                collectionView2 = CollectionViewSource.GetDefaultView(Context.Arbeitszeiten.Local.ToObservableCollection());

                var cv = collectionView2.Cast<Arbeitszeiten>().ToList();

                if (Monat == 0)
                {
                    cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).ToList();
                }

                else
                {
                    cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[1]) == Monat).ToList();
                }

                cv.ToList().Where(x => x.IdPersonal == p.IdPersonal).ToList().ForEach(x => PersonKosten += (decimal)x.Arbeitsstunden);

                PersonKosten = PersonKosten * (decimal)p.Stundenlohn;

                GesamtKosten += PersonKosten;
            }


            return GesamtKosten;
        }

        private decimal Ausgaben_Fixkosten_berechnen()
        {
            decimal Betrag = 0;

            Context.Fixkosten.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Fixkosten.Local.ToObservableCollection());
            var cv = CollectionView.Cast<Fixkosten>().ToList();

            if (Monat == 0)
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).ToList();
            }

            else
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[1]) == Monat).ToList();
            }

            cv.ToList().ForEach(x => Betrag += (decimal)x.Betrag);
            
            
            
            
            return Betrag;
        }


        private decimal Umsatz_InHouse_berechnen()
        {
            decimal Betrag = 0;
            
            Context.Verkauf.Load();

            CollectionView = CollectionViewSource.GetDefaultView(Context.Verkauf.Local.ToObservableCollection());
            var cv = CollectionView.Cast<Verkauf>().ToList();

            if (Monat == 0)
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).ToList();
            }

            else
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[1]) == Monat).ToList();
            }

            cv.Where(x => x.IdSteuersatz == 3).ToList().ForEach(x => Betrag += (decimal)x.BetragNetto);
            

            
            return Betrag;
        }

        private decimal Umsatz_ToGo_berechnen()
        {
            decimal Betrag = 0;

            Context.Verkauf.Load();

            CollectionView = CollectionViewSource.GetDefaultView(Context.Verkauf.Local.ToObservableCollection());
            var cv = CollectionView.Cast<Verkauf>().ToList();

            if (Monat == 0)
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).ToList();
            }

            else
            {
                cv = cv.Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[2]) == Jahr).Where(x => Convert.ToInt32(x.Datum.ToString().Split(' ')[0].Split('.')[1]) == Monat).ToList();
            }

            cv.Where(x => x.IdSteuersatz == 4).ToList().ForEach(x => Betrag += (decimal)x.BetragNetto);



            return Betrag;
        }

    }
    

    public partial class Calculation : UserControl
    {

        buchhaltungContext Context = new buchhaltungContext();
        ICollectionView CollectionView;
        Calc CalcContext;

        
        public Calculation()
        {
            InitializeComponent();
        }

     

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Jahre = new List<string>();
            Context.Einkauf.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());

            foreach (Einkauf ek in CollectionView)
            {
                
                if (!Jahre.Contains(ek.Datum.ToString().Split(' ')[0].Split('.')[2]))
                {
                    Jahre.Add(ek.Datum.ToString().Split(' ')[0].Split('.')[2]);
                }
                
                
            }

            Jahre.Sort();

            

            foreach(string s in Jahre)
            {
                if (!Select_Jahr.Items.Contains(s))
                    {
                        Select_Jahr.Items.Add(s);
                    }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Select_Jahr.SelectedItem != null )
            {

                var Jahr = Convert.ToInt32(Select_Jahr.SelectedItem.ToString());

                if (Select_Monat.SelectedItem != null)
                {
                    
                    var Monat = Convert.ToInt32(Select_Monat.SelectedItem.ToString().Split('-')[0].Split(' ')[1]);


                    CalcContext = new Calc(Jahr, Monat); 

                }

                else
                {
                    CalcContext = new Calc(Jahr);
                }

                GridCalculation.DataContext = CalcContext;
            }
        }
    }
}
