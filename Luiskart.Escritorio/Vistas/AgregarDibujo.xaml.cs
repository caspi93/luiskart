using luiskart.DataAcces;
using luiskart.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Luiskart.Escritorio.Vistas {
    /// <summary>
    /// Lógica de interacción para AgregarDibujo.xaml
    /// </summary>
    public partial class AgregarDibujo : Window {
        private string nombreDibujo;
        private Entidades db;
        private PersonajeDao personajeDao;
        private List<Personaje> personajes;
        private Func<Dibujo, bool> callbackGuardar;
        public AgregarDibujo(Entidades db, Func<Dibujo, bool> callbackGuardar) {
            InitializeComponent();
            this.callbackGuardar = callbackGuardar;
            this.db = db;
            personajeDao = new PersonajeDao(db);
            //var personajes = personajeDao.GetPersonajes();
            personajes = new List<Personaje>();
        }

        private void btnAgrePer_Click(object sender, RoutedEventArgs e) {
            var seleccionarPersonaje = new SeleccionarPersonaje(db, personaje => {
                personajes.Add(personaje);
                tblAnimePer.Items.Add(personaje);
                return true;
            });
            seleccionarPersonaje.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            using (var file = new System.Windows.Forms.OpenFileDialog()) {
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(file.FileName)) {
                    nombreDibujo = file.FileName;
                    imgNombreDibujo.Source = new BitmapImage(new Uri("file://" + nombreDibujo));
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            byte[] imagen = null;
            if (nombreDibujo != null) {
                imagen = File.ReadAllBytes(nombreDibujo);
            }

            var dibujo = new Dibujo {
                FechaCreacion = dateFechaCreacion.SelectedDate.Value,
                Imagen = imagen,
                PersonajesDibujos = personajes
                    .Select(p => new PersonajeDibujo { PersonajeId = p.Id })
                    .ToList()
            };

            var dibujoDao = new DibujoDao(db);
            dibujo = dibujoDao.CrearDibujo(dibujo);
            callbackGuardar(dibujo);
            Close();
        }

        private void btnElimPer_Click(object sender, RoutedEventArgs e) {
            var personaje = (Personaje)tblAnimePer.SelectedItem;
          
            var respuesta = MessageBox.Show("¿Desea eliminar a " + personaje.Anime.Nombre + " " + personaje.Nombre + "?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (respuesta == MessageBoxResult.Yes) {
                tblAnimePer.Items.Remove(personaje);
            }
        }
    }
}
