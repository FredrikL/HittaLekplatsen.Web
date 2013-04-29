using System.Collections.Generic;
using AutoMapper;
using Lekplatser.Api.Models;
using Lekplatser.Api.Repositories;
using Lekplatser.Dto;
using MongoDB.Bson;
using Nancy;

namespace Lekplatser.Api.Controllers
{
    public class PlaygroundsModule : NancyModule
    {
        private readonly IPlaygroundsRepository _repository;

        public PlaygroundsModule(IPlaygroundsRepository repository) :base("/Playgrounds")
        {
            _repository = repository;

            Get["/GetAll"] = x =>
            {
                IEnumerable<PlaygroundEntity> playgroundEntities = _repository.GetPlaygrounds();
                var ret = Mapper.Map<IEnumerable<PlaygroundEntity>, IEnumerable<Playground>>(playgroundEntities);
                return ret.ToJson();
            };

            Post["/Create"] = x =>
            {
                var entity = Mapper.Map<Playground, PlaygroundEntity>(null);
                var id = _repository.Add(entity);
                return id.ToString().ToJson();
            };
        }

/*        public IEnumerable<Playground> GetAll()
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
        */
    }
}