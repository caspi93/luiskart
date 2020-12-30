using Luiskart.Compartido.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luiskart.Compartido.DataAcces {
    public class DibujoDao {

        private LuiskartEntities db;

        public DibujoDao(LuiskartEntities db) {
            this.db = db;
        }

        public List<Dibujo> GetDibujos() {
            var consulta = from d in db.Dibujos orderby d.fechaIngreso descending select d;
            return consulta.ToList();
        }

        public List<Dibujo> GetDibujosConPersonajes() {
            return db.Dibujos.Include("PersonajesDibujos.Personaje.Anime").ToList();
        }

        public Dibujo GetDibujo(int id) {
            var consulta = from d in db.Dibujos where d.Id == id select d;

            return consulta.SingleOrDefault();
        }

        public Dibujo CrearDibujo(Dibujo dibujo) {
            dibujo.fechaIngreso = DateTime.Now;
            db.Dibujos.Add(dibujo);
            db.SaveChanges();
            db.Dibujos.Local.Clear();

            return GetDibujo(dibujo.Id);
        }
    }
}
