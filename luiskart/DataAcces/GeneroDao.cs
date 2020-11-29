using luiskart.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luiskart.DataAcces {
    public class GeneroDao {
        private Entidades db;

        public GeneroDao(Entidades db) {
            this.db = db;
        }

        public List<Genero> GetGeneros() {
            return db.Generos.ToList();
        }
    }
}
