﻿using MySql.Data.MySqlClient;
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
    /// Logika interakcji dla klasy Film.xaml
    /// </summary>
    public partial class Film : Window
    {
        public Film()
        {
            InitializeComponent();

            string connectionString = "SERVER=(localdb)\\Local;DATABASE=master;USER ID=PAWEŁ\\pawel;PASSWORD=";

            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand("select * from Filmy", connection);
            connection.Open();
            DataTable dt = new DataTable();

            dt.Load(command.ExecuteReader());
            connection.Close();

            TabelaFilm.DataContext = dt;

        }

        private void PowrótFilm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow rej = new MainWindow();
            rej.Show();

            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Projekt2._0.masterFilmoteka masterFilmoteka = ((Projekt2._0.masterFilmoteka)(this.FindResource("masterFilmoteka")));
            //// Załaduj dane do tabeli Filmy. Możesz modyfikować ten kod w razie potrzeby.
            //Projekt2._0.masterFilmotekaTableAdapters.FilmyTableAdapter masterFilmotekaFilmyTableAdapter = new Projekt2._0.masterFilmotekaTableAdapters.FilmyTableAdapter();
            //masterFilmotekaFilmyTableAdapter.Fill(masterFilmoteka.Filmy);
            //System.Windows.Data.CollectionViewSource filmyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmyViewSource")));
            //filmyViewSource.View.MoveCurrentToFirst();
        }

        private void WstawianieFilm_Click(object sender, RoutedEventArgs e)
        {
            DodawanieFilmu rej = new DodawanieFilmu();
            rej.Show();

            this.Close();
        }
        private void TabelaFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
