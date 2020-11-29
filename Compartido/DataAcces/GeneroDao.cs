using Luiskart.Compartido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.DataAcces {
    public class GeneroDao {
        private LuiskartEntities db;

        public GeneroDao(LuiskartEntities db) {
            this.db = db;
        }

        public List<Genero> GetGeneros() {
            return db.Generos.ToList();
        }
    }
}
