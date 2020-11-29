using luiskart.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luiskart.DataAcces {
    public class AnimeDao {

        private Entidades db;

        public AnimeDao(Entidades db) {
            this.db = db;
        }

        public List<Anime> GetAnimes() {
            return db.Animes.ToList();
        }

        public Anime CrearAnime(Anime anime) {
            db.Animes.Add(anime); 
            db.SaveChanges();
            return anime;
        }
    }
}
