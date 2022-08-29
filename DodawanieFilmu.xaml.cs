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
    /// Logika interakcji dla klasy DodawanieFilmu.xaml
    /// </summary>
    public partial class DodawanieFilmu : Window
    {
        public DodawanieFilmu()
        {
            InitializeComponent();
        }

        public static SqlConnection Get_Local_Connection()
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            if (conn.State != System.Data.ConnectionState.Open) conn.Open();

            return conn;

        }
        private void PowrotFilm_Click(object sender, RoutedEventArgs e)
        {
            Film rej = new Film();
            rej.Show();

            this.Close();
        }

        private void TloGlowne_Loaded(object sender, RoutedEventArgs e)
        {

            Projekt2._0.masterFilmoteka masterFilmoteka = ((Projekt2._0.masterFilmoteka)(this.FindResource("masterFilmoteka")));
            // Załaduj dane do tabeli Filmy. Możesz modyfikować ten kod w razie potrzeby.
            Projekt2._0.masterFilmotekaTableAdapters.FilmyTableAdapter masterFilmotekaFilmyTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.FilmyTableAdapter();
            masterFilmotekaFilmyTableAdapter.Fill(masterFilmoteka.Filmy);
            System.Windows.Data.CollectionViewSource filmyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmyViewSource")));
            filmyViewSource.View.MoveCurrentToFirst();
            // Załaduj dane do tabeli Reżyser. Możesz modyfikować ten kod w razie potrzeby.
            Projekt2._0.masterFilmotekaTableAdapters.ReżyserTableAdapter masterFilmotekaReżyserTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.ReżyserTableAdapter();
            masterFilmotekaReżyserTableAdapter.Fill(masterFilmoteka.Reżyser);
            System.Windows.Data.CollectionViewSource reżyserViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reżyserViewSource")));
            reżyserViewSource.View.MoveCurrentToFirst();
        }

        private void DodajFilm_Click(object sender, RoutedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query1 = "insert into Reżyser (Imię,Nazwisko) values ('" + this.imięTextBox + "','" + nazwiskoTextBox + "')";

                string Query = "insert into Filmy (Tytuł,Premiera,Reżyser,Status) values ('" + this.tytułTextBox.Text + "','" + this.premieraTextBox.Text + "','" + Query1 + "','" + this.statusTextBox.Text + "')" ;
                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zapisane :D");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
