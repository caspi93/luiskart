using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luiskart.Modelos {
    public partial class Personaje {

        public override string ToString() {
            return Nombre;
        }

        public string NombreCompleto {
            get {
                return Nombre + " (" + Anime.Nombre + ")";
            }
        }
    }
}
