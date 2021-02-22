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
using Database.Models;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Shell.Views
{
    /// <summary>
    /// Interaction logic for Calculation.xaml
    /// </summary>
    public partial class Calculation : UserControl
    {
        public Calculation()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
