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
    /// Logika interakcji dla klasy DodawanieSerial.xaml
    /// </summary>
    public partial class DodawanieSerial : Window
    {
        public DodawanieSerial()
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

        private void PowrotSerial_Click(object sender, RoutedEventArgs e)
        {
            Serial rej = new Serial();
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
            // Załaduj dane do tabeli Twórca. Możesz modyfikować ten kod w razie potrzeby.
            Projekt2._0.masterFilmotekaTableAdapters.TwórcaTableAdapter masterFilmotekaTwórcaTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.TwórcaTableAdapter();
            masterFilmotekaTwórcaTableAdapter.Fill(masterFilmoteka.Twórca);
            System.Windows.Data.CollectionViewSource twórcaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("twórcaViewSource")));
            twórcaViewSource.View.MoveCurrentToFirst();
        }

        private void DodajSerial_Click(object sender, RoutedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "insert into Serial (Tytuł,Premiera,Twórca,Status) values ('" + this.tytułTextBox.Text + "','" + this.premieraTextBox.Text + "','" + "8" + "','" + this.statusTextBox.Text + "')";
                string QueryTwórca = "insert into Twórca (Imię,Nazwisko) values ('" + this.imięTextBox.Text + "','" + nazwiskoTextBox.Text + "')";

                SqlCommand createCommand = new SqlCommand(Query, conn);
                SqlCommand createCommand1 = new SqlCommand(QueryTwórca, conn);

                createCommand.ExecuteNonQuery();
                createCommand1.ExecuteNonQuery();
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
