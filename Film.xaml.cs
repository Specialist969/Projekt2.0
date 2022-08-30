using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Logika interakcji dla klasy Film.xaml
    /// </summary>
    public partial class Film : Window
    {
        public Film()
        {
            InitializeComponent();
            combo();

            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT a.Tytuł,a.Premiera,a.Status,a.Reżyser, b.Imię , b.Nazwisko FROM Filmy a JOIN Reżyser b ON a.Reżyser = b.ID";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Filmy");
                adapter.Fill(dt);
                TablicaFilm.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void combo()
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT * FROM Filmy ";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                SqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string tytul = dr.GetString(1);
                    Combobox.Items.Add(tytul);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilmDodawanie_Click(object sender, RoutedEventArgs e)
        {
            DodawanieFilmu rej = new DodawanieFilmu();
            rej.Show();

            this.Close();
        }

        private void WrocFilm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow rej = new MainWindow();
            rej.Show();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Projekt2._0.masterFilmoteka masterFilmoteka = ((Projekt2._0.masterFilmoteka)(this.FindResource("masterFilmoteka")));
            // Załaduj dane do tabeli Filmy. Możesz modyfikować ten kod w razie potrzeby.
            Projekt2._0.masterFilmotekaTableAdapters.FilmyTableAdapter masterFilmotekaFilmyTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.FilmyTableAdapter();
            masterFilmotekaFilmyTableAdapter.Fill(masterFilmoteka.Filmy);
            System.Windows.Data.CollectionViewSource filmyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmyViewSource")));
            filmyViewSource.View.MoveCurrentToFirst();
            Projekt2._0.masterFilmotekaTableAdapters.ReżyserTableAdapter masterFilmotekaReżyserTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.ReżyserTableAdapter();
            masterFilmotekaReżyserTableAdapter.Fill(masterFilmoteka.Reżyser);
            System.Windows.Data.CollectionViewSource ReżyserViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reżyserViewSource")));
            filmyViewSource.View.MoveCurrentToFirst();
            
            
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT * FROM Filmy WHERE Tytuł='" + Combobox.Text + "' ";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                SqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string Status = dr.GetString(4);

                    textboxstatus.Text = Status;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpgradeFilm_Click(object sender, RoutedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "UPDATE Filmy SET Status='" + this.textboxstatus.Text + "' ";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zmieniony Status");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
