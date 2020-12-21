using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.Modelos_2 {
   public  class Anime {

        public Anime() { }

        public Anime(Modelos.Anime anime) {
            Id = anime.Id;
            Nombre = anime.Nombre;
            GeneroId = anime.GeneroId;
            FechaEstreno = anime.FechaEstreno;
            Portada = anime.Portada;
            Genero = new Genero(anime.Genero);
            Personajes = anime.Personajes.Select(p => new Personaje(p)).ToList();           
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public int GeneroId { get; set; }

        public DateTime FechaEstreno { get; set; }
        public byte[] Portada { get; set; }

        public Genero Genero { get; set; }

        public List<Personaje> Personajes { get; set; }

        public Modelos.Anime Convetir() {
            return new Modelos.Anime {
                Id = Id,
                Nombre = Nombre,
                GeneroId = GeneroId,
                FechaEstreno = FechaEstreno,
                Portada = Portada
            };
        }

    }
}
