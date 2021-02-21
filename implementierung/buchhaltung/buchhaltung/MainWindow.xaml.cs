﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shell.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace buchhaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollectionView CollectionView;

        private buchhaltungContext Context = new buchhaltungContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded (object sender, RoutedEventArgs e)
        {
            Context.Einkauf.Load();
            CollectionView = CollectionViewSource.GetDefaultView(Context.Einkauf.Local.ToObservableCollection());
            test.DataContext = CollectionView;
           
        }
    }
}
