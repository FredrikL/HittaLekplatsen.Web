using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using AutoMapper;
using Lekplatser.Api.Models;
using Lekplatser.Api.Repositories;
using Lekplatser.Api.Security;
using Lekplatser.Dto;

namespace Lekplatser.Api.Controllers
{
    public class PlaygroundsController : ApiController
    {
        private readonly IPlaygroundsRepository _repository;

        public PlaygroundsController(IPlaygroundsRepository repository)
        {
            _repository = repository;
        }

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [Admin]
        public IEnumerable<Playground> GetAll()
        {
            IEnumerable<PlaygroundEntity> playgroundEntities = _repository.GetPlaygrounds();
            var ret = Mapper.Map<IEnumerable<PlaygroundEntity>, IEnumerable<Playground>>(playgroundEntities);
            return ret;
        }

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