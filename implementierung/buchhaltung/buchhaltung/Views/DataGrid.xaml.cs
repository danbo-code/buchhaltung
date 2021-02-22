using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
using Database.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Shell.Views
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : UserControl
    {
        private ICollectionView CollectionView;

        private buchhaltungContext Context = new buchhaltungContext();


        public DataGrid()
        {
            InitializeComponent();
        }

        

        private void Auswahl_Tabelle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int auswahl = Convert.ToInt32(Auswahl_Tabelle.SelectedItem.ToString().Split(' ')[1]);

            switch (auswahl)
            {
                case 1:
                    Context.Einkauf.Load();
                    CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());
                    Anzeige_tabellen.DataContext = CollectionView;
                    break;

                case 2:
                    Context.Einkauf.Load();
                    CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());
                    
                    break;
            }
        }

        private bool Ausgabe_Filter(object o)
        {
            int auswahl = Convert.ToInt32(Auswahl_Tabelle.SelectedItem.ToString().Split(' ')[1]);
            bool filter = false;
            switch (auswahl)
            {
                case 2:
                    Einkauf food = o as Einkauf;
                    filter = food.IdSteuersatz == 1;
                    break;

                case 3:
                    Einkauf einkauf = o as Einkauf;
                    filter = einkauf.IdSteuersatz == 2;
                    break;

                case 5:
                    Verkauf inhouse = o as Verkauf;
                    filter = inhouse.IdSteuersatz == 3;
                    break;

                case 6:
                    Verkauf togo = o as Verkauf;
                    filter = togo.IdSteuersatz == 4;
                    break;

                default:
                    break;
            }
            return filter;
        }
    }
}
