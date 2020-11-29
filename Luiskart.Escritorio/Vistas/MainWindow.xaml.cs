using luiskart.DataAcces;
using luiskart.Modelos;
using Luiskart.Escritorio.Vistas;
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

namespace Luiskart.Escritorio {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private DibujoDao dibujoDao;
        private Entidades db;
        public MainWindow() {
            InitializeComponent();

            db = new Entidades();

            dibujoDao = new DibujoDao(db);
            var listaDibujos = dibujoDao.GetDibujos();


            foreach (var dibujo in listaDibujos) {
                panelDibujos.Children.Add(new ElementoDibujo(db,dibujo));
                //panelDibujos.Children.Add(new ElementoDibujo(dibujo));
            }
        }

        private void BtnAgregarDibujo_Click(object sender, RoutedEventArgs e) {
            var agregarDibujo = new AgregarDibujo(db, dibujo => {
                panelDibujos.Children.Add(new ElementoDibujo(db, dibujo));
                return true;
            });
            agregarDibujo.Show();
        }

        private void BtnVerAnimes_Click(object sender, RoutedEventArgs e) {
            var verAnimes = new VerAnimes(db);
            verAnimes.Show();
        }
    }
}
