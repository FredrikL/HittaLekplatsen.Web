using System.Collections.Generic;
using System.Web.Http;
using Lekplatser.Dto;
using Lekplatser.Shared.Repository;

namespace Lekplatser.Web.Api
{
    public class PlaygroundsController : ApiController
    {
        private readonly IPlaygroundRepository _repository;

        public PlaygroundsController(IPlaygroundRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Playground> GetByLocation(float lat, float lng)
        {
            return _repository.GetByLocation(lat, lng);
        } 
    }
}
