using Luiskart.Compartido.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para Veranime.xaml
    /// </summary>
    public partial class VerAnime : Window {
        private LuiskartEntities db;
        private Anime anime;

        public VerAnime(LuiskartEntities db, Anime anime, Personaje personaje) {
            InitializeComponent();

            this.db = db;
            this.anime = anime;
            
            var image = new BitmapImage();
            using (var ms = new MemoryStream(anime.Portada)) {
                ms.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = ms;
                image.EndInit();
            }

            imgPortada.Source = image;

            lblNombreAnime.Content = anime.Nombre;
            lblGenero.Content = "Género: " +  anime.Genero.Nombre;
            lblFechaEstreno.Content = "Fecha de Estreno: " + anime.FechaEstreno;
            listPersonajes.ItemsSource = anime.Personajes;
            if(personaje != null) {
                listPersonajes.SelectedItem = personaje;
            }
            

        }

        private void listPersonajes_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var personaje = (Personaje)listPersonajes.SelectedItem;

            var editarPersonaje = new EditarPersonaje(db, personaje);
            editarPersonaje.ShowDialog();
            
        }
    }
}
