using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Lekplatser.Dto;

namespace Lekplatser.Api.Controllers
{
    public class PlaygroundsController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IEnumerable<Playground> Get(float lat, float lng)
        {
            return Enumerable.Empty<Playground>();
        } 

        // GET api/values/5
        public Playground Get(string id)
        {
            return null;
        }

        // POST api/values
        public void Post([FromBody]Playground value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Playground value)
        {
        }

    }
}