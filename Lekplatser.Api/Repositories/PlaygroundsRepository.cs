using System.Collections.Generic;
using Lekplatser.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lekplatser.Api.Repositories
{
    public class PlaygroundsRepository : BaseRepository
    {
        public IEnumerable<Playground> GetPlaygrounds()
        {
            return GetCollection().FindAll();
        }

        public ObjectId Add(Playground p)
        {
            GetCollection().Insert(p);
            return p.Id;
        }

        public void Update(Playground p)
        {
            GetCollection().Save(p);
        }

        private MongoCollection<Playground> GetCollection()
        {
            return GetDataBase().GetCollection<Playground>("playgrounds");
        }
    }
}