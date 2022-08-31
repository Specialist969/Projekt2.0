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
    /// Logika interakcji dla klasy StatusSerial.xaml
    /// </summary>
    public partial class StatusSerial : Window
    {
        public StatusSerial()
        {
            InitializeComponent();
            comboserial();
            combotworca();
        }

        void comboserial()
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT * FROM Serial ";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                SqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string tytul = dr.GetString(1);
                    ComboBoxSerial.Items.Add(tytul);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void combotworca()
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT * FROM Twórca ";
                SqlCommand createCommand = new SqlCommand(Query, conn);
                SqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    string Nazwisko = dr.GetString(2);
                    ComboboxTworca.Items.Add(Nazwisko);
                    
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxSerial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT * FROM Serial WHERE Tytuł='" + ComboBoxSerial.Text + "' ";
                
                SqlCommand createCommand = new SqlCommand(Query, conn);
                
                SqlDataReader dr = createCommand.ExecuteReader();
                
                while (dr.Read())
                {
                    string Id = dr.GetString(0).ToString();
                    string Tytul = dr.GetString(1);
                    string Premiera = dr.GetString(2);
                    string Status = dr.GetString(4);

                    txtID.Content = Id;
                    TextTytul.Text = Tytul;
                    TextPremiera.Text = Premiera;                    
                    TextStatus.Text = Status;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PowrotSerial_Click(object sender, RoutedEventArgs e)
        {
            Serial rej = new Serial();
            rej.Show();

            this.Close();
        }

        private void ZapiszSerialStatus_Click(object sender, RoutedEventArgs e)
        {
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query1 = "UPDATE Twórca SET Imię='" + this.TextTworca.Text + "',Nazwisko='" + this.TextBoxTworca2.Text + "' WHERE ID='" + this.txtIDTworca.Content + "' ";
                string Query = "UPDATE Serial SET Tytuł='" + this.TextTytul.Text + "',Premiera='" + this.TextPremiera.Text + "',Status='" + this.TextStatus.Text + "' WHERE ID='" + this.txtID.Content + "' ";
                
                SqlCommand createCommand1 = new SqlCommand(Query1, conn);
                SqlCommand createCommand = new SqlCommand(Query, conn);
                createCommand1.ExecuteNonQuery();
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Zmieniony Status");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboboxTworca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string cn_String = Properties.Settings.Default.Filmotekamaster;
            SqlConnection conn = new SqlConnection(cn_String);
            try
            {
                conn.Open();
                string Query = "SELECT * FROM Twórca WHERE Imię='" + ComboboxTworca.Text + "' ";

                SqlCommand createCommand = new SqlCommand(Query, conn);

                SqlDataReader dr = createCommand.ExecuteReader();

                while (dr.Read())
                {
                    string Id = dr.GetString(0).ToString();
                    string Imie = dr.GetString(1);
                    string Nazwisko = dr.GetString(2);

                    txtIDTworca.Content = Id;
                    TextTworca.Text = Imie;
                    TextBoxTworca2.Text = Nazwisko;
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
