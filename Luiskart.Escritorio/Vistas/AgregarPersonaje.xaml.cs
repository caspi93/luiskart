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
    /// Lógica de interacción para AgregarPersonaje.xaml
    /// </summary>
    public partial class AgregarPersonaje : Window {
        private LuiskartEntities db;
        private Func<Personaje, bool> callbackGuardar;

        public AgregarPersonaje(LuiskartEntities db, Anime anime, Func<Personaje, bool> callbackGuardar) {
            InitializeComponent();
            this.callbackGuardar = callbackGuardar;

            this.db = db;
            var animeDao = new AnimeDao(db);
            var animes = animeDao.GetAnimes();
            foreach(Anime a in animes) {
                cbAnimes.Items.Add(a);

                if(anime.Id == a.Id) {
                    cbAnimes.SelectedItem = a;
                }
            }

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
            var personaje = new Personaje {
                Anime = (Anime)cbAnimes.SelectedItem,
                Nombre = txtNombre.Text
            };

            var personajeDao = new PersonajeDao(db);
            personajeDao.CrearPersonaje(personaje);
            personaje.Anime.Personajes.Add(personaje);
            callbackGuardar(personaje);
            Close();
        }
    }
}
