using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;
using System.Web.Http.ModelBinding;
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

        [HttpPost]
        public string Create(Playground value)
        {
            var entity = Mapper.Map<Playground, PlaygroundEntity>(value);
            var id = _repository.Add(entity);
            return id.ToString();
        }

        // PUT api/values/5
        public void Put(string id, [FromBody]Playground value)
        {
        }

    }
}