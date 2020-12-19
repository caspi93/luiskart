using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.Modelos {
    public partial class Personaje {

        public override string ToString() {
            return Nombre;
        }

        [JsonIgnore]
        public string NombreCompleto {
            get {
                return Nombre + " (" + Anime.Nombre + ")";
            }
        }
    }
}
