using Luiskart.Compartido.DataAcces;
using Luiskart.Compartido.Modelos_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Luiskart.Backend.Controllers {
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnimesController : ApiController {
        private Compartido.Modelos.LuiskartEntities db = new Compartido.Modelos.LuiskartEntities();
        // GET api/<controller>
        public IEnumerable<Anime> Get() {
            // var animeDao = new AnimeDao(db);
            // var animes = animeDao.GetAnimes();

            // return animes.Select(a => new Anime(a));

            var animes = new List<Anime>();
            var personajes = new List<Personaje>();
            var personajes2 = new List<Personaje>();
            personajes.Add(new Personaje { 
                Id = 1, 
                Nombre = "Sasuke", 
                AnimeId = 1
            });

            personajes2.Add(new Personaje {
                Id = 2,
                Nombre = "Goku",
                AnimeId = 2
            });

            personajes2.Add(new Personaje {
                Id = 3,
                Nombre = "Vegueta",
                AnimeId = 2
            });

            animes.Add(new Anime {
                Id = 1,
                Nombre = "Naruto",
                FechaEstreno = DateTime.Now,
                GeneroId = 1,
                Genero = new Genero() { Nombre = "Acción" },
                Personajes = personajes,
                Portada = new byte[5]
            });

            animes.Add(new Anime {
                Id = 2,
                Nombre = "Dragon Ball", 
                FechaEstreno = DateTime.Now, 
                GeneroId = 1, 
                Genero = new Genero() {Nombre = "Aventura" },
                Personajes = personajes2,
                Portada = new byte[5] 
            });

            animes.Add(new Anime {
                Id = 3,
                Nombre = "Pokemon",
                FechaEstreno = DateTime.Now,
                GeneroId = 1,
                Genero = new Genero() { Nombre = "Aventura en pañales" },
                Personajes = new List<Personaje>(),
                Portada = new byte[5]
            });

            return animes; 
        }

        // GET api/<controller>/5
        public string Get(int id) {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value) {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}