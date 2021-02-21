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

namespace Shell.Views
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : UserControl
    {
        private ICollectionView CollectionView;

        private Database.Models.buchhaltungContext Context = new buchhaltungContext();


        public DataGrid()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context.Einkauf.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());
            test.DataContext = CollectionView;
        }
    }
}
