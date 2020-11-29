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
    /// Lógica de interacción para ElementoDibujo.xaml
    /// </summary>
    public partial class ElementoDibujo : UserControl {
        private Dibujo dibujo;
        private Entidades db;
        public ElementoDibujo(Entidades db, Dibujo dibujo) {
            InitializeComponent();
            this.db = db;
            this.dibujo = dibujo;

            if (dibujo.FechaCreacion.HasValue) {
                lblFechaCreacion.Content = dibujo.FechaCreacion.ToString();
            }

            lblFechaIngreso.Content = dibujo.fechaIngreso.ToString();



            lblContPersonajes.Content = string.Join(", ", dibujo.Personajes.Select(p => p.NombreCompleto));
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
        }

        public override string ToString() {
            return dibujo.fechaIngreso.ToString();
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var verDibujo = new VerDibujo(db, dibujo);
            verDibujo.Show();
        }
    }
}

