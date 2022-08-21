using System;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Projekt2._0.masterFilmoteka masterFilmoteka = ((Projekt2._0.masterFilmoteka)(this.FindResource("masterFilmoteka")));
            // Załaduj dane do tabeli Serial. Możesz modyfikować ten kod w razie potrzeby.
            Projekt2._0.masterFilmotekaTableAdapters.SerialTableAdapter masterFilmotekaSerialTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.SerialTableAdapter();
            masterFilmotekaSerialTableAdapter.Fill(masterFilmoteka.Serial);
            System.Windows.Data.CollectionViewSource serialViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("serialViewSource")));
            serialViewSource.View.MoveCurrentToFirst();
        }

        private void WstawianieSerial_Click(object sender, RoutedEventArgs e)
        {
            DodawanieSerial rej = new DodawanieSerial();
            rej.Show();

            this.Close();
        }
    }
}
