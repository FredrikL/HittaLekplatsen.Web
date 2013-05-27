using System;
using System.Collections.Generic;
using Lekplatser.Dto;

namespace Lekplatser.Web.Repository
{
    public class PlaygroundsRepository : IPlaygroundsRepository
    {
        public IEnumerable<Playground> GetByLocation(float lat, float lng)
        {
            throw new NotImplementedException();
        }
    }
}