using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luiskart.Modelos {
    public partial class Dibujo {
        public IEnumerable<Personaje> Personajes {
            get {
                return PersonajesDibujos.Select(pd => pd.Personaje);
            }
        }
    }
}
