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
        public IEnumerable<Anime2> Get() {
             var animeDao = new AnimeDao(db);
             var animes = animeDao.GetAnimes();

             return animes.Select(a => new Anime2(a));
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