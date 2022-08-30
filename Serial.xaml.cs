using System;
using System.Collections.Generic;
using System.Data;
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
            

            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT a.Id,a.Tytuł,a.Premiera,a.Status,a.Twórca, b.Imię , b.Nazwisko FROM Serial a JOIN Twórca b ON a.Twórca = b.ID\r\n";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Serial");
                adapter.Fill(dt);
                TabelaSerial1.ItemsSource = dt.DefaultView;
                
                adapter.Update(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void TabelaSerial_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void UpgradeSerial_Click(object sender, RoutedEventArgs e)
        {
            //StatusSerial rej = new StatusSerial();
            //rej.Show();

            //this.Close();
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "UPDATE Serial SET Tytuł='" + this.txtTytul.Text + "',Premiera='" + this.txtPremiera.Text + "',Status='" + this.txtStatus.Text + "' WHERE ID='" + this.txtID.Content + "' ";

                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand.ExecuteNonQuery();
                
                MessageBox.Show("Zmieniony Status");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TabelaSerial1.Items.Refresh();





        }
    }
}
