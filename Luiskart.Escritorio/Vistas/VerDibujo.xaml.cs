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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace  Luiskart.Escritorio.Vistas {
    /// <summary>
    /// Lógica de interacción para VerDibujo.xaml
    /// </summary>
    public partial class VerDibujo : Window {
        private Dibujo dibujo;
        private LuiskartEntities db;
        public VerDibujo(LuiskartEntities db, Dibujo dibujo) {
            InitializeComponent();
            this.db = db;
            this.dibujo = dibujo;

            var image = new BitmapImage();
            using (var ms = new MemoryStream(dibujo.Imagen)) {
                ms.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = ms;
                image.EndInit();
            }

            imgDibujo.Source = image;

            lblFechaCreacion.Content = dibujo.FechaCreacion.ToString();
            lblFechaIngreso.Content = dibujo.fechaIngreso.ToString();

            listPersonajes.ItemsSource = dibujo.Personajes.Select(p => p.NombreCompleto);
        }

        private void listPersonajes_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var posicion = listPersonajes.SelectedIndex;
            var personaje = dibujo.Personajes.ElementAt(posicion);
            var verAnime = new VerAnime(db, personaje.Anime, personaje);
            verAnime.Show();
        }

        private void btnDescargar_Click(object sender, RoutedEventArgs e) {
            using (var file = new SaveFileDialog()) {
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(file.FileName)) {
                    
                    File.WriteAllBytes(file.FileName, dibujo.Imagen);
                }
            }
        }
    }
}
