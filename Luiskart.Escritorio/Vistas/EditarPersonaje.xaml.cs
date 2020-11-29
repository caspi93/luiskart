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
    /// Lógica de interacción para EditarPersonaje.xaml
    /// </summary>
    public partial class EditarPersonaje : Window {
        private Personaje personaje;
        private LuiskartEntities db;

        public EditarPersonaje(LuiskartEntities db, Personaje personaje) {
            InitializeComponent();
            this.db = db;
            this.personaje = personaje;

            txtNombre.Text = personaje.Nombre;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e) {
            personaje.Nombre = txtNombre.Text;

            var personajeDao = new PersonajeDao(db);
            personajeDao.EditarPersonaje(personaje);
            Close();
        }
    }
}
