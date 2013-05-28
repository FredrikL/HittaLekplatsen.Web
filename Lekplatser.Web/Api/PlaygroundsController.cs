using System.Collections.Generic;
using System.Web.Http;
using Lekplatser.Dto;
using Lekplatser.Web.Repository;

namespace Lekplatser.Web.Api
{
    public class PlaygroundsController : ApiController
    {
        private readonly IPlaygroundsRepository _repository;

        public PlaygroundsController(IPlaygroundsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Playground> GetByLocation(float lat, float lng)
        {
            return _repository.GetByLocation(lat, lng);
        } 
    }
}
