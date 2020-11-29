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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;


namespace Luiskart.Escritorio.Vistas {
    /// <summary>
    /// Lógica de interacción para AgregarAnime.xaml
    /// </summary>
    public partial class AgregarAnime : Window {
        private LuiskartEntities db;
        private string nombrePortada;
        public AgregarAnime(LuiskartEntities db) {
            InitializeComponent();

            this.db = db;
            var generoDao = new GeneroDao(db);
            var generos = generoDao.GetGeneros();

            foreach (Genero g in generos) {
                cbGeneros.Items.Add(g);
            }
        }

        private void btnSelectImg_Click(object sender, RoutedEventArgs e) {
            using (var file = new OpenFileDialog()) {
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(file.FileName)) {
                    nombrePortada = file.FileName;
                    imgPortada.Source = new BitmapImage(new Uri("file://" + nombrePortada));
                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e) {
            byte[] portada = null;
            if (nombrePortada != null) {
                portada = File.ReadAllBytes(nombrePortada);
            }
            
            var anime = new Anime {
                Nombre = txtNombre.Text,
                Genero = (Genero)cbGeneros.SelectedItem,
                FechaEstreno = dtFechaEstreno.SelectedDate.Value,
                Portada = portada
            };

            var animeDao = new AnimeDao(db);
            animeDao.CrearAnime(anime);
            Close();
        }

    }
}
