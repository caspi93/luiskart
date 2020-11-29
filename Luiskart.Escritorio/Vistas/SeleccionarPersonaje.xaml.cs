using Luiskart.Compartido.DataAcces;
using Luiskart.Compartido.Modelos;
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

namespace  Luiskart.Escritorio.Vistas {
    /// <summary>
    /// Lógica de interacción para SeleccionarPersonaje.xaml
    /// </summary>
    public partial class SeleccionarPersonaje : Window {
        private LuiskartEntities db;
        private Func<Personaje, bool> callbackGuardar;
        private List<Anime> animes;
        private Anime anime = null;
        public SeleccionarPersonaje(LuiskartEntities db, Func<Personaje, bool> callbackGuardar) {
            InitializeComponent();
            this.callbackGuardar = callbackGuardar;

            this.db = db;
            var animeDao = new AnimeDao(db);
             animes = animeDao.GetAnimes();
            foreach(Anime a in animes) {
                cbAnimes.Items.Add(a);
            }

        }

        private void btnAgregarAnime_Click(object sender, RoutedEventArgs e) {
            var agregarAnime = new AgregarAnime(db);
            agregarAnime.Show();
        }

        private void btnAgregarPersonaje_Click(object sender, RoutedEventArgs e) {
            var anime = (Anime)cbAnimes.SelectedItem;
            var agregarPersonaje = new AgregarPersonaje(db, anime, personaje => {
                if(anime.Id == personaje.Anime.Id) {
                    cbPersonajes.Items.Add(personaje);
                }
                
                return true;
            });
            agregarPersonaje.Show();
        }

        private void cbAnimes_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var posicion = cbAnimes.SelectedIndex;
            anime = animes[posicion];
            if(anime != null) {
                cbPersonajes.Items.Clear();
                cbPersonajes.IsEnabled = true;
                btnAgregarPersonaje.IsEnabled = true;
                foreach (Personaje p in anime.Personajes) {
                    cbPersonajes.Items.Add(p);
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
            var posicion = cbPersonajes.SelectedIndex;
            var personaje = anime.Personajes.ElementAt(posicion);
            callbackGuardar(personaje);
            Close();
        }
    }
}
