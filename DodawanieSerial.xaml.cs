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
using System.Windows.Shapes;

namespace Projekt2._0
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieSerial.xaml
    /// </summary>
    public partial class DodawanieSerial : Window
    {
        public DodawanieSerial()
        {
            InitializeComponent();
        }

        private void PowrotSerial_Click(object sender, RoutedEventArgs e)
        {
            Serial rej = new Serial();
            rej.Show();

            this.Close();
        }

        
    }
}
