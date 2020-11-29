using luiskart.Modelos;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Luiskart.Escritorio.Vistas {
    /// <summary>
    /// Lógica de interacción para ElementoAnime.xaml
    /// </summary>
    public partial class ElementoAnime : UserControl {
        private Entidades db;
        private Anime anime;

        public ElementoAnime(Entidades db, Anime anime) {
            InitializeComponent();

            this.db = db;
            this.anime = anime;

            lblNombre.Content = anime.Nombre.ToString();
            lblFechaEstreno.Content = "Fecha de Estreno: " + anime.FechaEstreno.ToString();
            lblGenero.Content = "Género: "+ anime.Genero.Nombre.ToString();

            lblContPersonajes.Content = "Personajes: " + string.Join(", ", anime.Personajes);
            var portada = new BitmapImage();
            using (var ms = new MemoryStream(anime.Portada)) {
                ms.Position = 0;
                portada.BeginInit();
                portada.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                portada.CacheOption = BitmapCacheOption.OnLoad;
                portada.UriSource = null;
                portada.StreamSource = ms;
                portada.EndInit();
            }

            imgPortada.Source = portada;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var verAnime = new VerAnime(db, anime, null);
            verAnime.Show();
        }
    }
}

