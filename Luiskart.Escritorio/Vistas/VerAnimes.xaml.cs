using Luiskart.Compartido.DataAcces;
using Luiskart.Compartido.Modelos;
using  Luiskart.Escritorio.Vistas;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace  Luiskart.Escritorio {
    /// <summary>
    /// Lógica de interacción para VerAnimes.xaml
    /// </summary>
    public partial class VerAnimes : Window {
        private AnimeDao animeDao;
        private LuiskartEntities db;

        public VerAnimes(LuiskartEntities db) {
            InitializeComponent();

            this.db = db;
            animeDao = new AnimeDao(db);
            ActualizarAnimes();
        }

        private void BtnAgregarAnime_Click(object sender, RoutedEventArgs e) {
            var agregarAnime = new AgregarAnime(db);
            agregarAnime.Show();
        }

        private void ActualizarAnimes() {
            var listaAnimes = animeDao.GetAnimes();
            panelAnimes.Children.Clear();
            foreach (var anime in listaAnimes) {
                panelAnimes.Children.Add(new ElementoAnime(db, anime)); 
            }
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e) {
            ActualizarAnimes();
        }
    }
}
