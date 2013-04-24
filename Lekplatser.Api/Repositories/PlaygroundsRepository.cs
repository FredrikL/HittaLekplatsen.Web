using System.Collections.Generic;
using Lekplatser.Api.Models;
using MongoDB.Driver;

namespace Lekplatser.Api.Repositories
{
    public class PlaygroundsRepository : BaseRepository
    {
        public IEnumerable<Playground> GetPlaygrounds()
        {
            return GetDataBase().GetCollection<Playground>("playgrounds").FindAll();
        }

        
    }

    public class BaseRepository
    {
        protected MongoDatabase GetDataBase()
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            return server.GetDatabase("playgrounds");
        }
    }
}