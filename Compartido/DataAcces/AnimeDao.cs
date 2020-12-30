using Luiskart.Compartido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.DataAcces {
    public class AnimeDao {

        private LuiskartEntities db;

        public AnimeDao(LuiskartEntities db) {
            this.db = db;
        }

        public List<Anime> GetAnimes() {
            var consulta = from a in db.Animes orderby a.Nombre select a;
            return consulta.ToList();
        }

        public Anime CrearAnime(Anime anime) {
            db.Animes.Add(anime); 
            db.SaveChanges();
            return anime;
        }
    }
}
