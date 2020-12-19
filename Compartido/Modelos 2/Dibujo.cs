using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.Modelos_2 {
    public class Dibujo {

        public Dibujo() { }

        public Dibujo(Modelos.Dibujo dibujo) {
            Id = dibujo.Id;
            Imagen = dibujo.Imagen;
            FechaCreacion = dibujo.FechaCreacion;
            FechaIngreso = dibujo.fechaIngreso;
            Personajes = dibujo.Personajes.Select(p => new Personaje(p)).ToList();
        }
        public int Id { get; set; }
        public byte[] Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime FechaIngreso { get; set; }

        public List<Personaje> Personajes { get; set; }

        public Modelos.Dibujo Convertir() {
            return new Modelos.Dibujo {
                Id = Id,
                Imagen = Imagen,
                FechaCreacion = FechaCreacion,
                fechaIngreso = FechaIngreso
            };
        }
    }
}
