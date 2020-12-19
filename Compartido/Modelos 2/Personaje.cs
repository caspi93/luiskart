using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.Modelos_2 {
    public class Personaje {
        public Personaje() { }
        public Personaje(Modelos.Personaje personaje) {
            Id = personaje.Id;
            Nombre = personaje.Nombre;
            AnimeId = personaje.AnimeId;
            Anime = new Anime(personaje.Anime);
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public Modelos.Personaje Convertir() {
            return new Modelos.Personaje {
                Id = Id,
                Nombre = Nombre,
                AnimeId = AnimeId,
            };
        }
    }
}
