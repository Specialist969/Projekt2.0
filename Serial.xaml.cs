using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy Serial.xaml
    /// </summary>
    public partial class Serial : Window
    {
        public Serial()
        {
            InitializeComponent();
        }

        private void PowrotSerial_Click(object sender, RoutedEventArgs e)
        {
            MainWindow rej = new MainWindow();
            rej.Show();

            this.Close();
        }

        

        private void WstawianieSerial_Click(object sender, RoutedEventArgs e)
        {
            DodawanieSerial rej = new DodawanieSerial();
            rej.Show();

            this.Close();
        }

        
    }
}
