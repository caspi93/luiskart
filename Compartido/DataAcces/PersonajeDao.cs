using Luiskart.Compartido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.DataAcces {
    public class PersonajeDao {

        private LuiskartEntities db;

        public PersonajeDao(LuiskartEntities db) {
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
