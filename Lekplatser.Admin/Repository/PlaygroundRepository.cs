using System.Collections.Generic;
using System.Linq;
using Lekplatser.Dto;

namespace Lekplatser.Admin.Repository
{
    public class PlaygroundRepository : IPlaygroundRepository
    {
        public IEnumerable<Playground> GetAll()
        {
            return Enumerable.Empty<Playground>();
        }
    }
}