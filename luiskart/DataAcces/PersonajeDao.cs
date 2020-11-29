using luiskart.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luiskart.DataAcces {
    public class PersonajeDao {

        private Entidades db;

        public PersonajeDao(Entidades db) {
            this.db = db;
        }

        public List<Personaje> GetPersonajes() {
            return db.Personajes.ToList();
        }

        public Personaje CrearPersonaje(Personaje personaje) {
            db.Personajes.Add(personaje);
            db.SaveChanges();
            return personaje;
        }

        public Personaje EditarPersonaje(Personaje personaje) {
            db.SaveChanges();
            return personaje;
        }
    }
}
