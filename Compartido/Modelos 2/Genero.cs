using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.Modelos_2 {
    public class Genero {

        public Genero() { }

        public Genero(Modelos.Genero genero) {

            Id = genero.Id;
            Nombre = genero.Nombre;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public Modelos.Genero Convertir() {
            return new Modelos.Genero {
                Id = Id,
                Nombre = Nombre
            };
        }

    }
}
