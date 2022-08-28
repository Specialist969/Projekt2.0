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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt2._0
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void Filmprzycisk_Click(object sender, RoutedEventArgs e)
        {
            Film rej = new Film();
            rej.Show();

            this.Close();
        }

        private void Serialprzycisk_Click(object sender, RoutedEventArgs e)
        {
            Serial rej = new Serial();
            rej.Show();

            this.Close();
        }
    }
}
