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
            

            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT a.ID,a.Tytuł,a.Premiera,a.Status,a.Reżyser, b.Imię , b.Nazwisko FROM Filmy a JOIN Reżyser b ON a.Reżyser = b.ID";
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

        

        private void UpgradeFilm_Click(object sender, RoutedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "UPDATE Filmy SET Tytuł='" + this.txtTytul.Text + "',Premiera='" + this.txtPremiera.Text + "',Status='" + this.txtStatus.Text + "' WHERE ID='" + this.txtID.Content + "' ";

                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand.ExecuteNonQuery();

                MessageBox.Show("Zmieniony Status");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TablicaFilm.Items.Refresh();
        }

        private void TablicaFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView drv = dg.SelectedItem as DataRowView;
            if (drv != null)
            {
                txtID.Content = drv["ID"].ToString();
                txtTytul.Text = drv["Tytuł"].ToString();
                txtPremiera.Text = drv["Premiera"].ToString();
                txtStatus.Text = drv["Status"].ToString();
            }
        }
    }
}
